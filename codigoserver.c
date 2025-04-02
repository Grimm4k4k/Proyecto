#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql/mysql.h>
#include <pthread.h>
pthread_mutex_t mutex= PTHREAD_MUTEX_INITIALIZER;

typedef struct{
	char nombre[100];
	int socket;
}Conectado;

typedef struct{
	Conectado conectados[100];
	int num;
}ListaConectados;

char conectados[100];
ListaConectados *listaCon;

int addCon (ListaConectados *lista, char nombre[100],int socket){
	lista->num=0;
	if(lista->num==100){
		return -1;
	}
	strcpy(lista->conectados[lista->num].nombre, nombre);
	lista->conectados[lista->num].socket=socket;
	lista->num++;
	return 0;
}

int dameSocket (ListaConectados *lista, char nombre[100]){ //No devuelve el numero del socket como tal sino su posicion
	int i =0;
	int encontrado =0;
	while((i<lista->num)&&(encontrado==0)){
		if(strcmp(lista->conectados[i].nombre,nombre)==0){
			encontrado=1;
		}
		if(encontrado==0){
			i++;
		}
	}
		if(encontrado==1)
		   return i;
		if(encontrado==0)
			return -1;
}

int eliminarCon(ListaConectados *lista, char nombre[100]){
	int posSocket= dameSocket(lista,nombre);
	if(posSocket==-1){
		return -1;
	}
	for(int i=posSocket;i<lista->num-1;i++){
		lista->conectados[i] = lista->conectados[i+1];
	}
	lista->num--;
	return 0;
}

void dameConectados(ListaConectados *lista,char conectados[300]){//Pone en el vetor del parametro todos los conectados (Formato:l/Numero total/nombre/nombre/nombre)
	sprintf(conectados,"l/%d",lista->num);
	for(int i=0;i<lista->num;i++){
		sprintf(conectados, "%s/%s",conectados,lista->conectados[i].nombre);
	}
}

void *AtenderCliente (void *socket){
	int sock_conn;
	int *s;
	s= (int *) socket;
	sock_conn= *s;
	
	//int socket_conn = * (int *) socket;
	
	char peticion[512];
	char respuesta[512];
	int ret;
	char copiaPeticion[512];
	char consulta[256];
	
	int err,num; 
	MYSQL_RES *resultado; 
	MYSQL_ROW row;
	MYSQL *conn;
	
	conn = mysql_init(NULL);
	if (conn == NULL) {
		printf("Error al crear la conexión: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit(1);
	}
	
	conn = mysql_real_connect(conn, "localhost", "root", "mysql", "poker", 0, NULL, 0);
	if (conn == NULL) {
		printf("Error al inicializar la conexión: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit(1);
	}
	
	int terminar =0;int cambios=0;
	// Entramos en un bucle para atender todas las peticiones de este cliente
	//hasta que se desconecte
	while (terminar ==0)
	{
		// Ahora recibimos la petici?n
		ret=read(sock_conn,peticion, sizeof(peticion));
		printf ("Recibido\n");
		if(ret!=-1){
		// Tenemos que a?adirle la marca de fin de string 
		// para que no escriba lo que hay despues en el buffer
		peticion[ret]='\0';
		strcpy(copiaPeticion,peticion);
		char *p = strtok(peticion, "/");
		int NumPeticion = atoi(p);
		printf ("Peticion: %s\n",peticion);
		
		// Ya tenemos el numero de la peticion
		char IdUsuario[20];
		char Contra[20];
		if(NumPeticion != 0)
		{
			p = strtok( NULL, "/");
			strcpy (IdUsuario, p);
			// Ya tenemos el usuario
			p = strtok( NULL, "/");
			strcpy (Contra, p);
			//Ya tenemos la contraseña
		}
		switch(NumPeticion)
		{
		case 0://terminar peticion
		{
			int res = eliminarCon(listaCon,IdUsuario);
			terminar = 1; 
			cambios=1;
		}
		break;
			
		case 1://registrarse
		{
			
			char DNI[20];
			char nombre[20];
			int edad;
			p = strtok( NULL, "/");
			strcpy (DNI, p);//Ya tenemos la DNI
			p = strtok( NULL, "/");
			strcpy (nombre, p);//Ya tenemos la contraseña
			p = strtok( NULL, "/");
			edad = atoi(p);//Ya tenemos la edad
			pthread_mutex_lock(&mutex);
			consulta[0] = '\0';//liberar cosulta
			printf("antes de la consulta"),
				sprintf(consulta, "INSERT INTO jugadores VALUES('%s','%s','%s','%s',%d) " ,IdUsuario ,Contra ,DNI ,nombre ,edad);
			printf("despues de la consulta"),
				printf("Error MySQL: %s\n", mysql_error(conn));
			err = mysql_query(conn, consulta);
			pthread_mutex_unlock(&mutex);
			if (err != 0) 
			{
				printf("Error al registrarse");
				strcpy(respuesta, "0");//Operacion no realizada.
				// Enviamos respuesta
				write (sock_conn,respuesta, strlen(respuesta));
			}
			else{
				printf("Te has registrado con exito.");
				strcpy(respuesta, "1");//Operacion realizada con exito.
				// Enviamos respuesta
				write (sock_conn,respuesta, strlen(respuesta)+1);
			}
		}
		break;
		
		case 2://login
		{
			consulta[0] = '\0';//liberar cosulta
			sprintf(consulta, "SELECT contra FROM jugadores WHERE jugadores.id_jugador = '%s'", IdUsuario);
			err = mysql_query(conn, consulta);
			if (err != 0) {
				printf("El usuario introducido es incorrecto");
				strcpy(respuesta, "0");//Operacion no realizada.
				// Enviamos respuesta
				write (sock_conn,respuesta, strlen(respuesta));
			}
			else
			{
				resultado = mysql_store_result(conn);
				if(resultado == NULL) {
					printf("Error al obtener el resultado de la consulta.\n");
					strcpy(respuesta, "0");//Operacion no realizada.
					// Enviamos respuesta
					write (sock_conn,respuesta, strlen(respuesta));
				}
				row = mysql_fetch_row(resultado);
				if(strcmp(Contra,row[0]) == 0){
					printf("Has iniciado sesion con exito.");
					strcpy(respuesta, "1");//Operacion realizada con exito.
					// Enviamos respuesta
					write (sock_conn,respuesta, strlen(respuesta)+1);
					
					//actualizamos lista
					pthread_mutex_lock(&mutex);
					int res = addCon(listaCon, IdUsuario, sock_conn);
					cambios=1;
					pthread_mutex_unlock(&mutex);
				}			
			}
		}
		break;
		
		case 3: //Ver jugadores de una partdia con IDx 
		{
			char IdPartida[20];
			p = strtok( copiaPeticion, "/");
			p = strtok( NULL, "/");
			p = strtok( NULL, "/");
			strcpy (IdPartida, p);//Ya tenemos la Id de la partida
			consulta[0] = '\0';//liberar cosulta
			sprintf(consulta, "SELECT participantes.idJ FROM participantes WHERE participantes.idP = '%s' AND NOT participantes.idJ='%s'"
					, IdPartida, IdUsuario);
			err = mysql_query(conn, consulta);
			if (err != 0) {  
				printf("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
				strcpy(respuesta,'0');//Operacion no realizada.
				// Enviamos respuesta
				write (sock_conn,respuesta, strlen(respuesta));
			}
			// Obtener resultado
			resultado = mysql_store_result(conn);
			if (resultado == NULL) {
				printf("Error al obtener el resultado de la consulta.\n");
				mysql_close(conn);
				strcpy(respuesta,'0');//Operacion no realizada.
				// Enviamos respuesta
				write (sock_conn,respuesta, strlen(respuesta));
			}
			else{
				row = mysql_fetch_row(resultado);
				sprintf(respuesta,"consulta3/");
				while(row != NULL){
					strcat(respuesta,row[0]);
					sprintf(respuesta,"%s/",respuesta);
					row=mysql_fetch_row(resultado);
				}
				respuesta[(strlen(respuesta)-1)]= '\0';
				write (sock_conn,respuesta, strlen(respuesta)+1);
			}
		}
		break;
		
		case 4://personas con las que he jugado
		{
			// Consultar partidas en las que ha participado
			sprintf(consulta, "SELECT participantes.idP FROM participantes WHERE participantes.idJ = '%s'", IdUsuario);
			if (mysql_query(conn, consulta) != 0) {
				printf("Error al consultar partidas: %u %s\n", mysql_errno(conn), mysql_error(conn));
				mysql_close(conn);
				exit(1);
			}
			resultado = mysql_store_result(conn);
			if (resultado == NULL) {
				printf("Error al obtener el resultado de la consulta.\n");
				mysql_close(conn);
				exit(1);
			}
			else{
				sprintf(respuesta,"consulta4/");
				MYSQL_RES *resultado2;
				row = mysql_fetch_row(resultado);
				
				while(row!=NULL)
				{
					sprintf(consulta, "SELECT participantes.idJ FROM participantes WHERE participantes.idP= '%s' AND NOT participantes.idJ='%s'"
							, row[0],IdUsuario);
					err = mysql_query(conn, consulta);
					if (err != 0) {  
						printf("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
						strcpy(respuesta,'0');//Operacion no realizada.
						// Enviamos respuesta
						write (sock_conn,respuesta, strlen(respuesta));
					}
					resultado2 = mysql_store_result(conn);
					row = mysql_fetch_row(resultado2);
					
					while(row != NULL){
						strcat(respuesta,row[0]);
						sprintf(respuesta,"%s/",respuesta);
						row=mysql_fetch_row(resultado2);
					}
					row = mysql_fetch_row(resultado);
				}
				respuesta[(strlen(respuesta)-1)]= '\0';
				// Enviamos respuesta
				write (sock_conn,respuesta, strlen(respuesta)+1);
			}
			break;
			
		case 5:
		{
			
		}
		break;
		
		default:
			printf("Peticion incorrecta.");
			break;
		}
		terminar = 1;
		// Se acabo el servicio para este cliente
		}
		if (cambios==1)
		{
			for(int i=0; i< listaCon->num; i++){
			pthread_mutex_lock(&mutex);	
			dameConectados(listaCon,conectados);
			conectados[strlen(conectados)]='\0';
			write(listaCon->conectados[i].socket,conectados,strlen(conectados)+1);
			pthread_mutex_unlock(&mutex);
			}
			cambios=0;
		}
	}
		else{
			terminar=1;
		}
	}
	mysql_close(conn);
	close(sock_conn);
	
}

int main(int argc, char *argv[])
{
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char peticion[512];
	char respuesta[100];
	listaCon = (struct ListaConectados *)malloc(sizeof(ListaConectados));
	if (listaCon == NULL) {
		perror("Error al asignar memoria");
		exit(1);
	}
	listaCon->num = 0;
	
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Fem el bind al port
	
	
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// establecemos el puerto de escucha
	serv_adr.sin_port = htons(9005);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	
	if (listen(sock_listen, 3) < 0){
		printf("Error en el Listen");
	}
	int j=0;
	int sockets[100];
	pthread_t thread;
	
	// Bucle infinito
	for (;;){
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		//sock_conn es el socket que usaremos para este cliente
		
		sockets[j] = sock_conn;
		
		//Crear thread y decirle lo que tiene que hacer
		pthread_create (&thread, NULL, AtenderCliente, &sockets[j]);
		j++;
	}}
