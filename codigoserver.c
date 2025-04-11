#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql/mysql.h>
#include <pthread.h>
#include <time.h>

#define puerto 50010

pthread_mutex_t mutex= PTHREAD_MUTEX_INITIALIZER;
typedef struct{
	char nombre[100];
	int socket;
}Conectado;

typedef struct{
	Conectado conectados[100];
	int num;
}ListaConectados;

typedef struct {
	int estado;
	int numJugadores;
	char host[100];
	int fichasHost;
	char j2[100];
	int fichasJ2;
	char j3[100];
	int fichasJ3;
	char j4[100];
	int fichasJ4;
	char fechaInicio[10];
}Partida;

char conectados[100];
char noDisponibles[500];
ListaConectados listaCon;
Partida listaPartidas[100];
int maxPartidas = 100;

int crearPartida(char nombreHost[100]) {
	//Si se ha creado partida, retorna su posición en la listaPartidas
	//Retorna -1 si la listaPartidas está llena
	int i = 0;
	int encontrado = 0;
	while ((i < maxPartidas) && (encontrado==0))
	{
		pthread_mutex_lock(&mutex);
		if (listaPartidas[i].estado == 0)
		{
			listaPartidas[i].estado = 1;
			strcpy(listaPartidas[i].host, nombreHost);
			listaPartidas[i].fichasHost = 0;

			strcpy(listaPartidas[i].j2, "\0");
			listaPartidas[i].fichasJ2 = 0;

			strcpy(listaPartidas[i].j3, "\0");
			listaPartidas[i].fichasJ3 = 0;

			strcpy(listaPartidas[i].j4, "\0");
			listaPartidas[i].fichasJ4 = 0;

			strcpy(listaPartidas[i].fechaInicio,"\0");
			encontrado = 1;
		}
		else
			i++;
		pthread_mutex_unlock(&mutex);

	}
	if (encontrado == 0)
		return -1;
	else {
		return i;
	}
}

int eliminarPartida(int partida){
	listaPartidas[partida].estado = 0;
	listaPartidas[partida].numJugadores = 0;

	strcpy(listaPartidas[partida].host, "\0");
	listaPartidas[partida].fichasHost = 0;

	strcpy(listaPartidas[partida].j2, "\0");
	listaPartidas[partida].fichasJ2 = 0;

	strcpy(listaPartidas[partida].j3, "\0");
	listaPartidas[partida].fichasJ3 = 0;
	strcpy(listaPartidas[partida].j4, "\0");
	listaPartidas[partida].fichasJ4 = 0;

	strcpy(listaPartidas[partida].fechaInicio , "\0");
}

void rechazarPartida(int partida, char rechazador[25], int socket) {
	char rechazada[500];
	sprintf(rechazada, "partidaRechazada/%d*%s", partida, rechazador);
	enviarNotificacion(rechazada, partida, socket);
}

void iniciarPartida(int partida, char jugadoresPartida[500]) {
	char respuesta[100];
	sprintf(respuesta, "partidaIniciada/%d*%s", partida, jugadoresPartida);
	printf("Iniciar partida: %s\n", respuesta);
	int socket1 = dameSocket(listaPartidas[partida].host);
	if (socket1 != -1) {
		char respuesta2[100];
		sprintf(respuesta2, "%s*%s", respuesta, "host");
		printf("%s\n", respuesta2);
		write(socket1, respuesta2, strlen(respuesta2));
	}
	int socket2 = dameSocket(listaPartidas[partida].j2);
	if (socket2 != -1) {
		char respuesta2[100];
		sprintf(respuesta2, "%s*%s", respuesta, "j2");
		printf("%s\n", respuesta2);
		write(socket2, respuesta2, strlen(respuesta2));
	}

	if (strcmp(listaPartidas[partida].j3, "0") != 0) {
		int socket3 = dameSocket(listaPartidas[partida].j3);
		if (socket3 != -1) {
			char respuesta2[100];
			sprintf(respuesta2, "%s*%s", respuesta, "j3");
			printf("%s\n", respuesta2);
			write(socket3, respuesta2, strlen(respuesta2));
		}
	}
	if (strcmp(listaPartidas[partida].j4, "0") != 0) {
		int socket4 = dameSocket(listaPartidas[partida].j4);
		if (socket4 != -1) {
			char respuesta2[100];
			sprintf(respuesta2, "%s*%s", respuesta, "j4");
			printf("%s\n", respuesta2);
			write(socket4, respuesta2, strlen(respuesta2));
		}
	}
	time_t t = time(NULL);
	struct tm* tm_info = localtime(&t);
	// Formato:dd/mm/yyyy hh:mm:ss
	strftime(listaPartidas[partida].fechaInicio, sizeof(listaPartidas[partida].fechaInicio), "%d/%m/%Y %H:%M:%S", tm_info);
}

void enviarNotificacion(char notificacion[500], int partida, int socket) {
	int socket1 = dameSocket(listaPartidas[partida].host);
	if ((socket1 != -1) && (socket1 != socket)) {
		write(socket1, notificacion, strlen(notificacion));
		printf("'%s' enviado a socket %d \n", notificacion, socket1);
	}
	int socket2 = dameSocket(listaPartidas[partida].j2);
	if ((socket2 != -1) && (socket2 != socket)) {
		write(socket2, notificacion, strlen(notificacion));
		printf("'%s' enviado a socket %d \n", notificacion, socket2);
	}

	if (strcmp(listaPartidas[partida].j3, "0") != 0) {
		int socket3 = dameSocket(listaPartidas[partida].j3);
		if ((socket3 != -1) && (socket3 != socket))
		{
			write(socket3, notificacion, strlen(notificacion));
			printf("'%s' enviado a socket %d \n", notificacion, socket3);
		}
	}
	if (strcmp(listaPartidas[partida].j4, "0") != 0) {
		int socket4 = dameSocket(listaPartidas[partida].j4);
		if ((socket4 != -1) && (socket4 != socket)) {
			write(socket4, notificacion, strlen(notificacion));
			printf("'%s' enviado a socket %d \n", notificacion, socket4);
		}
	}
}

int invitarJugador(char invitados[500], char nombreHost[25], char noDisponibles[500], int partida) { //nombreHost:persona que invita; noDisponibles: usuarios no conectados
	//Devuelve numero de invitados si todo ha ido bien
	//Devuelve -1 si alguno de los usuarios invitados se ha desconectado
	strcpy(noDisponibles, "\0");
	int res = 0;
	char* t = strtok(invitados, "*");
	int numInvitados = 0;

	while (t!= NULL) {
		int encontrado = 0;
		int i = 0;
		while ((i < listaCon.num) && (encontrado == 0)) {
			if (strcmp(listaCon.conectados[i].nombre, t) == 0) {
				char invitacion[512];
				sprintf(invitacion, "recibirInvitacion/%s*%d", nombreHost, partida);
				printf("Invitacion: %s\n", invitacion);
				write(listaCon.conectados[i].socket, invitacion, strlen(invitacion)); //envia invitación a los jugadores invitados
				encontrado = 1;
				numInvitados = numInvitados + 1;
			}
			else
				i = i + 1;
		}
		if (encontrado == 0) {
			res = -1;
			sprintf(noDisponibles, "%s%s*", noDisponibles, t);
			noDisponibles[strlen(noDisponibles) - 1] = '\0';
		}
		t = strtok(NULL, "*");
	}
	if (res == 0) {
		res = numInvitados;
		pthread_mutex_lock(&mutex);
		listaPartidas[partida].numJugadores = numInvitados + 1;
		pthread_mutex_unlock(&mutex);
	}

	return res;
}

int addJugador(char nombre[25], int partida) {
	//Devuelve 1 si se han añadido todos los jugadores correctamente
	int numInvitados = listaPartidas[partida].numJugadores-1;
	pthread_mutex_lock(&mutex);
	if (strcmp(listaPartidas[partida].j2, "0") == 0) {
		strcpy(listaPartidas[partida].j2, nombre);
	}
	else if (strcmp(listaPartidas[partida].j3, "0") == 0)
		strcpy(listaPartidas[partida].j3, nombre);
	else if (strcmp(listaPartidas[partida].j4, "0") == 0)
		strcpy(listaPartidas[partida].j4, nombre);

	numInvitados = numInvitados-1;
	int res = numInvitados;
	pthread_mutex_unlock(&mutex);
	return res;
}

int dameJugadoresPartida(int partida, char jugadores[500]) {
	sprintf(jugadores, "%s*%s", listaPartidas[partida].host, listaPartidas[partida].j2);
	int numJugadores = 2;
	if (strcmp(listaPartidas[partida].j3, "0") != 0) {
		sprintf(jugadores, "%s*%s", jugadores, listaPartidas[partida].j3);
		numJugadores = numJugadores + 1;
		if (strcmp(listaPartidas[partida].j4, "0") != 0) {
			sprintf(jugadores, "%s*%s", jugadores, listaPartidas[partida].j4);
			numJugadores = numJugadores + 1;
		}
	}
	return numJugadores;
}

int addCon (ListaConectados *lista, char nombre[100],int socket){
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
	int posSocket= dameSocket(&lista,nombre);
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
	strcpy(conectados[0], "\0");
	sprintf(conectados,"l/%d/",lista->num);
	for(int i=0;i<lista->num;i++){
		sprintf(conectados, "%s/%s",conectados,lista->conectados[i].nombre);
	}
}

void damePartidasJugador(char nombre[25], char partidas[100]) {//lista todas las partidas en las que el jugador del parametro esta participando
	//las retorna con el formato:partida1/partida2/...
	int i = 0;
	strcpy(partidas, "\0");
	while (i < maxPartidas)
	{
		if ((strcmp(nombre, listaPartidas[i].host) == 0) || (strcmp(nombre, listaPartidas[i].j2) == 0) || (strcmp(nombre, listaPartidas[i].j3) == 0) || (strcmp(nombre, listaPartidas[i].j4) == 0))
			sprintf(partidas, "%s%d/", partidas, i);
		i = i + 1;
	}
	partidas[strlen(partidas) - 1] = '\0';
}

void *AtenderCliente (void *socket){
	int sock_conn;
	int *s;
	s= (int *) socket;
	sock_conn= *s;
	
	char peticion[512];
	char respuesta[512];
	int ret;
	char copiaPeticion[512];
	char consulta[256];
	char IdUsuario[20];
	char Contra[20];
	
	int err,num; 
	MYSQL_RES *resultado; 
	MYSQL_ROW row;
	MYSQL *conn;
	
	conn = mysql_init(NULL);
	if (conn == NULL) {
		printf("Error al crear la conexión: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit(1);
	}
	
	conn = mysql_real_connect(conn, "shiva2.upc.es", "root", "mysql", "M3_BBDDPoker", 0, NULL, 0);
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
		case 0://terminar conexion
		{
			pthread_mutex_lock(&mutex);
			int res = eliminarCon(&listaCon,IdUsuario);
			char partidas[100];
			printf("Conexion cerrada\n");
			damePartidasJugador(IdUsuario, partidas);
			char* p = strtok(partidas, "/");
			while (p != NULL)
			{
				int partida = atoi(p);
				eliminarPartida(partida);
				p = strtok(NULL, "/");
			}
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
			printf("antes de la consulta\n"),
				sprintf(consulta, "INSERT INTO jugadores VALUES('%s','%s','%s','%s',%d) " ,IdUsuario ,Contra ,DNI ,nombre ,edad);
			printf("despues de la consulta\n"),
				printf("Error MySQL: %s\n", mysql_error(conn));
			err = mysql_query(conn, consulta);
			pthread_mutex_unlock(&mutex);
			if (err != 0) 
			{
				printf("Error al registrarse\n");
				strcpy(respuesta, "0");//Operacion no realizada.
				// Enviamos respuesta
				write (sock_conn,respuesta, strlen(respuesta));
			}
			else{
				printf("Te has registrado con exito.\n");
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
				printf("El usuario introducido es incorrecto\n");
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
					int res = addCon(&listaCon, IdUsuario, sock_conn);
					cambios=1;
					pthread_mutex_unlock(&mutex);
				}			
			}
		}
		break;
		
		case 3: //Consulta 3:Ver jugadores de una partdia con IDx 
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
		
		case 4://Consulta4: personas con las que he jugado
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
			
		case 5: //Consulta5: partidas jugadas en un periodo de tiempo
		{
			MYSQL_ROW row2;
			MYSQL_RES *resultado2;
			p = strtok( NULL, "/");
			int tiempo = atoi(p);
			int contpartidas = 0;
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
				row = mysql_fetch_row(resultado);
			}
			consulta[0] = '\0';//liberar cosulta
			for(int i=0; i < mysql_num_fields(resultado); i++){
				sprintf(consulta, "SELECT partidas.duracion FROM partidas, participantes WHERE partidas.id_partida = '%s'", row[i]);
				if (mysql_query(conn, consulta) != 0) {
					printf("Error al consultar partidas: %u %s\n", mysql_errno(conn), mysql_error(conn));
					mysql_close(conn);
					exit(1);
				}
				resultado2 = mysql_store_result(conn);
				if (resultado2 == NULL) {
					printf("Error al obtener el resultado de la consulta.\n");
					mysql_close(conn);
					exit(1);
				}
				else{
					row2 = mysql_fetch_row(resultado2);
					if(tiempo >= atoi(row2[0])){
						contpartidas++;
						tiempo = tiempo - atoi(row2[0]);
					}
				}
			}
			respuesta[0] = '\0';
			char strcont[200];
			sprintf(strcont, "%d",contpartidas);
			sprintf(respuesta,"consulta5/");
			strcat(respuesta,strcont);
			respuesta[(strlen(respuesta))]= '\0';
			// Enviamos respuesta
			write (sock_conn,respuesta, strlen(respuesta));
			
		}
		break;
		
		case 6: //Enviar invitacion
		{
			p = strtok(NULL, "/");
			char invitados[500];
			printf("Numero de invitados: %d Invitados: %s\n", sock_conn, invitados);
			char noDisponibles[500];
			strcpy(invitados, p);

			printf("Numero de socket: %d\n", sock_conn);
			int partida = crearPartida(IdUsuario);
			if (partida == -1)
				sprintf(respuesta, "recibirInvitacion/-1");
			else {
				printf("Numero de socket : %d\n", sock_conn);
				int res = invitarJugador(invitados, IdUsuario, noDisponibles, partida);

				if (res == -1) {
					sprintf(respuesta, "recibirInvitacion/%s", noDisponibles);
				}
				else {
					strcpy(respuesta, "recibirInvitacion/0");
				}
			}
		}
		break;

		case 7://Recibir respuesta a una invitacion
		{
			char respuesta2[3];
			p = strtok(NULL, "/");
			strcpy(respuesta2, p);
			p = strtok(NULL, "/");
			int idPartida;
			idPartida = atoi(p);
			if (strcmp(respuesta2, "NO") == 0) {
				printf("Numero de socket: %d\n", sock_conn);
				rechazarPartida(idPartida, IdUsuario, sock_conn);
				pthread_mutex_lock(&mutex);
				eliminarPartida(idPartida);
				pthread_mutex_unlock(&mutex);
			}
			else {
				int res = addJugador(IdUsuario, idPartida);
				if (res == 0) {
					printf("Numero de socket: %d; Añadido a la partida %s\n", sock_conn, IdUsuario);
					char jugadoresPartida[500];
					dameJugadoresPartida(idPartida, jugadoresPartida);
					printf("Numero de socket: %d\n", sock_conn);
					iniciarPartida(idPartida, jugadoresPartida);
				}
			}
		}
		break;

		default:
			printf("Peticion incorrecta\n");
			break;
		}
		terminar = 1;
		// Se acabo el servicio para este cliente
		}
		if (cambios==1)
		{
			for(int i=0; i< listaCon.num; i++){
			pthread_mutex_lock(&mutex);	
			dameConectados(&listaCon,conectados);
			conectados[strlen(conectados+1)]='\0';
			write(listaCon.conectados[i].socket,conectados,strlen(conectados));
			pthread_mutex_unlock(&mutex);
			}
			cambios=0;
		}
	}
		else{
			terminar=1;
			int r = eliminarCon(&listaCon,IdUsuario);
			if(r==0){
				for(int i=0; i< listaCon.num; i++){
			pthread_mutex_lock(&mutex);	
			dameConectados(&listaCon,conectados);
			conectados[strlen(conectados)]='\0';
			write(listaCon.conectados[i].socket,conectados,strlen(conectados));
			pthread_mutex_unlock(&mutex);
			}
			}
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
	
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket\n");
	// Fem el bind al port
	
	
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// establecemos el puerto de escucha
	serv_adr.sin_port = htons(puerto);
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
