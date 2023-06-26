#include <stdio.h>
#include <string.h>
#include <unistd.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdlib.h>
#include <mysql.h>
#include <pthread.h>
//Estructura para acceso excluyente
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

typedef struct{
	char username[25];
	int socket;
}Conectado;

typedef struct{
	Conectado conectados [100];
	int num;
}ListaConectados;
ListaConectados milista;

typedef struct
{
	Conectado jugadores[4];
	int id;
	int libre;
	
} TMulti;

typedef TMulti TPartidas[100];
int num;
TPartidas mitabla;



void iniciartabla()
{

	for (int i=0; i<100; i++)
	{

		mitabla[i].libre=0;
		mitabla[i].id=i;
	}
	
}

void ReiniciarTabla()
{
	for (int i=0; i<100; i++)
	{
		strcpy(mitabla[i].jugadores[0].username,"");
		strcpy(mitabla[i].jugadores[1].username,"");
		mitabla[i].libre=0;
		mitabla[i].id=i;
		
		
	}
}


int anadeConectado (ListaConectados *milista, char username[20], int socket)
{
	if (milista->num == 100)
		return -1;
	
	else
	{
		int i = 0;
		int encontrado = 0;
		while ((i < milista->num) && (encontrado==0))
		{
			if(strcmp(milista->conectados[i].username, username)==0)
			{
				encontrado = 1;
			}
			else 
			   i=i+1;
		}
		if(encontrado==0)
		{
			strcpy (milista->conectados[milista->num].username, username);
			milista->conectados[milista->num].socket = socket;
			milista->num++;
			printf("añadido\n");
			return 0;
		}
		else 
		{
			printf("Ya conectado\n");
			return -2;
		}
		
		
	}
}

int DameSocket (ListaConectados *milista, char username[20])
{
	int i=0;
	int encontrado = 0;
	while ((i < milista->num) && (encontrado==0))
	{
		if (strcmp(milista->conectados[i].username, username) == 0)
			encontrado =1;
		else
			i=i+1;
	}
	if (encontrado==1)
		return milista->conectados[i].socket;
	else
		return -1;
}


int eliminaConectado (ListaConectados *milista, char username[20], char respuesta[512])
{
	printf("%s\n",username);
	int encontrado=0;
	int i=0;
	while((encontrado==0)&&(i<milista->num))
	{
		if(strcmp(username,milista->conectados[i].username)==0)
		{
			encontrado==1;
			for (i;i<milista->num;i++)
			{
				strcpy(milista->conectados[i].username,milista->conectados[i+1].username);
				milista->conectados[i].socket=milista->conectados[i+1].socket;
			}
			milista->num--;
		}
		else
			i++;
	}
	sprintf(respuesta,"0/");
	
}

void EliminarUsuario(MYSQL *conn, char respuesta[512], char username[20], char passwd[20], int sock_conn)
{
	pthread_mutex_lock(&mutex);
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta [512];
	char consulta2 [512];
	sprintf (consulta2,"SELECT jugador.username FROM (jugador) WHERE jugador.username = '%s' AND jugador.passwd = '%s';", username, passwd); 
	
	int err=mysql_query (conn, consulta2);
	if (err!=0) {
		printf ("Error en la consulta en la base de datos %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	if (row == NULL)
	{
		printf ("11/Nombre o contraseña incorrectos\n");
		strcpy(respuesta,"11/Nombre o contraseña incorrectos\n");
	}
	else{
		
		
		sprintf(consulta,"DELETE FROM jugador WHERE username = '%s' AND passwd = '%s';", username, passwd);
		err= mysql_query(conn, consulta);
		if(err !=0){
			printf("Error al consultar la base de datos %u %s\n", mysql_errno(conn),mysql_error(conn));
			exit(1);
			
		}	
		
		sprintf(respuesta,"11/Usuario eliminado de la BBDD\n");
		printf("\n");
	}

	pthread_mutex_unlock(&mutex);
}

void login(MYSQL *conn, char respuesta[512], char username[20], char passwd[20], int sock_conn)
{
	
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta [512];
	printf("brooooo");
	sprintf (consulta,"SELECT jugador.username FROM (jugador) WHERE jugador.username = '%s' AND jugador.passwd = '%s';", username, passwd); 
	
	int err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error en la consulta en la base de datos %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	printf("bro tas pasao");
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL)
	{
		printf ("4/Nombre o contraseña incorrectos\n");
		strcpy(respuesta,"4/Nombre o contraseña incorrectos\n");
	}
	else
	{		
		pthread_mutex_lock( &mutex );	
		int res = anadeConectado(&milista,username,sock_conn);
		pthread_mutex_unlock(&mutex);
		if (res==-1)
		{
			sprintf(respuesta, "4/Log in erroneo, tabla llena");
		}
		else if (res ==-2)
		{
			sprintf(respuesta, "4/Ya estas logueado");
		}
		
		else
		{
			sprintf(respuesta, "4/Log in completado");
		}
	}
	printf("%s\n",respuesta);
	printf("\n");
	
}

void signin(MYSQL *conn, char respuesta[512], char username[25], char passwd[25], int sock_conn)
{
	pthread_mutex_lock( &mutex );
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[512];
	char consulta2 [512];
	int id;

	sprintf(consulta2,"SELECT (COUNT(jugador.username))+1 FROM (jugador)");
	int err=mysql_query (conn, consulta2);
	if (err!=0){
		printf ("5/Error al consultar datos de la base %u %s\n",mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	if (row == NULL){
		printf("No se han obtenido datos\n");
	}
	else{
		if(row!= NULL){
			id = atoi(row[0]);
			row = mysql_fetch_row(resultado);
		}
		sprintf(consulta,"INSERT INTO jugador VALUES('%d', '%s', '%s')", id, username, passwd);
		err= mysql_query(conn, consulta);
		if(err !=0){
			printf("Error al consultar la base de datos %u %s\n", mysql_errno(conn),mysql_error(conn));
			exit(1);
			
		}	
			
		int res = anadeConectado(&milista,username,sock_conn);
		
		sprintf(respuesta,"5/Registrado\n");
		printf("\n");
	}	
	pthread_mutex_unlock(&mutex);

}

void jugadoresciudad(MYSQL *conn, char ciudad[25], char respuesta[200])
{
	pthread_mutex_lock( &mutex ); //No me interrumpas ahora
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[512];
	strcpy(consulta, "SELECT jugador.username FROM (jugador, partida) WHERE partida.ganador = jugador.username AND partida.ciudad = '");
	strcat(consulta, ciudad);
	strcat(consulta, "'");

	int err=mysql_query (conn, consulta);
	if(err!=0)
	{
		printf("Error en la consulta\n");
		exit(1);
	}
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	if(row == NULL)
	{
		printf("1/No hay datos");
	}

	else
	{
		
		strcat(respuesta, "1/");
		strcat(respuesta, row[0]);

	}
	pthread_mutex_unlock(&mutex);
	
}

void ganadorpartida(MYSQL *conn, int idpartida, char respuesta[512])
{
	pthread_mutex_lock( &mutex );
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[512];
	sprintf(consulta, "SELECT jugador.username FROM (partida, jugador) WHERE jugador.username = partida.ganador AND partida.idpartida = '%d'", idpartida);
	int err = mysql_query(conn, consulta);
	if(err!=0)
	{
		printf("Error en la consulta\n");
		exit(1);
	}
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	if(row == NULL)
	{
		printf("2/No hay datos");
	}

	else
	{
		
		strcat(respuesta, "2/");
		strcat(respuesta, row[0]);

	}
	pthread_mutex_unlock(&mutex);
	
}

int dameposicion(MYSQL *conn, char username[25], char respuesta[512])
{
	pthread_mutex_lock( &mutex );
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[512];

	sprintf(consulta, "SELECT CLASIFICACION.posicion FROM (jugador, CLASIFICACION) WHERE jugador.username = '%s' AND jugador.id = CLASIFICACION.jugador_id", username);
	int err = mysql_query(conn, consulta);
	if(err!=0)
	{
		printf("Error en la consulta\n");
		exit(1);
	}
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	if(row == NULL)
	{
		printf("3/No hay datos\n");
	}
	else
	{
		respuesta = row[0];
		printf("3/%s\n", respuesta);
		char codigo[10]= "3/";
		strcat(codigo, respuesta);
	}
}
void mostrarConectados(char respuesta[512])
{
	pthread_mutex_lock(&mutex);
	char respuestaAUX[512];
	memset(respuestaAUX, 0, 512);
	sprintf(respuesta,"6/%d|",milista.num);
	int i; 
	for (i=0; i<milista.num; i++)
	{
		sprintf(respuestaAUX,"%s%s|",respuestaAUX,milista.conectados[i].username);
	}
	respuestaAUX[strlen(respuestaAUX)-1] = '\0';
	strcat(respuesta,respuestaAUX);
	printf("%s\n",respuesta);
	printf("\n");
	pthread_mutex_unlock(&mutex);
}

void DameCompanero(ListaConectados *milista, char username1[25], char username2[25])
{
	int i=0;
	int encontrado =0;
	while (i<100 && encontrado==0)
	{
		
		if(strcmp(mitabla[i].jugadores[0].username,username1)== 0)
		{
			encontrado = 1;
		}
		else if(strcmp(mitabla[i].jugadores[1].username,username1)== 0)
		{
			encontrado = 2;
		}
		else
		{
			i= i+1;
		}
	}
	if(encontrado==1)
	{
		strcpy(username2,mitabla[i].jugadores[1].username);
	}
	else if(encontrado == 2)
	{
		strcpy(username2,mitabla[i].jugadores[0].username);
	}
	else
	{
		printf("Username no encontrado\n");
	}		
}		

int crearpartida(char listajugadores[512], int socket)
{
	int i=0;
	int encontrado=0;
	while(i<100 && encontrado==0)
	{
		if(mitabla[i].libre==0)
		{
			encontrado=1;
			mitabla[i].libre=1;
		}
		else
		   i++;
	}
	
	if (encontrado==0)
	{
		return -1;
	}
	else
	{
		int j=0;
		int encontrado=0;
		while(j<milista.num && encontrado==0) // saca el nombre del usuario
		{
			if(milista.conectados[j].socket==socket)
			{
				encontrado=1;
			}
			else
			   j++;
		}
		
		strcpy(mitabla[i].jugadores[0].username,milista.conectados[j].username);
		mitabla[i].jugadores[0].socket=socket;
		printf("Host socket: %d\n",mitabla[i].jugadores[0].socket);
		char copia[200];
		strcpy(copia,listajugadores);
		char *p = strtok(copia, "-"); //separamos por guiones los nombres
		int k=1;
		while(p!=NULL)
		{
			strcpy(mitabla[i].jugadores[k].username,p); // buscamos usuarios invitados
			j=0;
			encontrado=0;
			while(j<milista.num && encontrado==0)
			{
				if(strcmp(milista.conectados[j].username,p)==0)
				{
					encontrado=1;
				}
				else
				   j++;
			}	
			mitabla[i].jugadores[k].socket=milista.conectados[j].socket;
			k++;
			p=strtok(NULL,"-");
		}
		return mitabla[i].id;
	}

}

//eliminar una partida
void eliminarpartida(int id)
{
	int i=0;
	while(i<2)
	{
		strcpy(mitabla[id].jugadores[i].username, "");
		mitabla[id].jugadores[i].socket = -1;
		i++;
	}
}

void invitacion (char username[512], int sock_inv, char respuesta[512]) 	
{
	sprintf(respuesta,"7/%s\n", username);
	printf("%s\n",respuesta);
}

//respuesta a invitacion recibida
void invitacionrespuesta(ListaConectados *milista, char invitado[20], int sock_conn, char respuesta[512], int idpartida)
{
	char respuesta2[512];
	char *p;
	int res;
	int acepta;
	p=strtok(NULL, "/");
	acepta = atoi(p);
	printf("acepta: %d\n",acepta);
	sprintf(respuesta2, "8/%s", invitado);

	if (acepta == 0)
	{
		sprintf(respuesta,"8/%d/%s/%d",idpartida, invitado,acepta);
		int i=0;
		while(strcmp(mitabla[idpartida].jugadores[i].username,"")!=0)
		{
			write(mitabla[idpartida].jugadores[i].socket, respuesta, strlen(respuesta));
			i++;
		}
	}
	else
	{
		sprintf(respuesta,"8/%d/%s/1",idpartida, invitado);
		eliminarpartida(idpartida);
		
	}
}

void *atendercliente(void *socket)
{
	int sock_conn;
	int *s;
	s= (int *) socket;
	sock_conn= *s;
	
	char mensaje[512];
	char respuesta[512];
	char notificacion[512];
	int ret;
	MYSQL *conn;
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	conn = mysql_init(NULL);
	if (conn==NULL) 
	{
		printf ("Error al crear la conexion: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	conn = mysql_real_connect (conn, "shiva2.upc.es","root","mysql","M8_BBDDJuego",0, NULL, 0); //M8_BBDDJuego shiva2.upc.es
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	int acabar =0;
	while(acabar==0)
	{
		memset(respuesta, 0, 512);
		memset(notificacion, 0, 512);
		printf("\n");
		printf ("Esperando peticion\n");
		ret=read(sock_conn,mensaje, sizeof(mensaje));
		printf ("peticion recibida\n");
		mensaje[ret]='\0';
		int terminar;
		char *p = strtok(mensaje, "/");
		char *p1;
		int codigo =  atoi (p);
		int res;
		char username[25];
		char passwd[25];
		char invitado[25];
		char listajugadores[512];
		int idpartida;
		switch(codigo)
		{
		case 0:
			p=strtok(NULL,"/");
			strcpy(username,p);
			eliminaConectado(&milista, username, respuesta);
			write(sock_conn, respuesta, strlen(respuesta));
			mostrarConectados(notificacion);
			printf(notificacion);
			for (int j = 0; j < milista.num; j++)
				write(milista.conectados[j].socket,notificacion,strlen(notificacion));
			break;
			//terminar=1;
		break;
		case 1:
			p=strtok(NULL,"/");
			printf("holaguapo\n");
			jugadoresciudad(conn, p, respuesta);
			printf("Holaatendercliente\n");
			write(sock_conn, respuesta, strlen(respuesta));
			
		break;
		case 2:
			p=strtok(NULL,"/");
			dameposicion(conn, p, respuesta);
			write(sock_conn, respuesta, strlen(respuesta));
			
		break;
		case 3:
			p=strtok(NULL,"/");
			idpartida = atoi(p);
			ganadorpartida(conn, idpartida, respuesta);
			write(sock_conn, respuesta, strlen(respuesta));
			
		break;
		case 4:
			p=strtok(NULL,"/");
			char u[20];
			strcpy(u, p);
			p=strtok(NULL,"/");
			char s[20];
			strcpy(s, p);
			login(conn, respuesta, u, s, sock_conn);
			write(sock_conn, respuesta, strlen(respuesta));
			mostrarConectados(notificacion);
			for (int j = 0; j < milista.num; j++)
				write(milista.conectados[j].socket,notificacion,strlen(notificacion));
			break;
		break;
		case 5:
			p=strtok(NULL,"/");
			char x[20];
			strcpy(x,p);
			p=strtok(NULL,"/");
			char z[20];
			strcpy(z, p);
			signin(conn, respuesta, x, z, sock_conn);
			write(sock_conn, respuesta, strlen(respuesta));
			mostrarConectados(notificacion);
			for (int j = 0; j < milista.num; j++)
				write(milista.conectados[j].socket,notificacion,strlen(notificacion));
			break;
			
		break;
		case 6:
			mostrarConectados(notificacion);
			write (sock_conn,respuesta,strlen(respuesta));
		break;
		case 7:
			p=strtok(NULL,"/");
			sprintf(listajugadores,"%s",p);
			printf("%s\n",listajugadores);
			
			int idpartida = crearpartida(listajugadores,sock_conn);
			sprintf(respuesta,"7/%d/%s/%s",idpartida,mitabla[idpartida].jugadores[0].username,listajugadores);
			printf("%s\n",respuesta);
			int i=1;
			while(strcmp(mitabla[idpartida].jugadores[i].username,"")!=0)
			{
				write(mitabla[idpartida].jugadores[i].socket,respuesta,strlen(respuesta));
				i++;
			}
			
			char lider[25];
			strcpy(lider, mitabla[idpartida].jugadores[0].username);
			int socket_lider = DameSocket(&milista, lider);
			char notificacion_lider[512];
			sprintf(notificacion_lider,"12/Eres el lider de la partida\n");
			write(socket_lider,notificacion_lider,strlen(notificacion_lider));
			
			char companero1[25];
			DameCompanero(&milista,lider,companero1);
			int socket_compa = DameSocket(&milista, companero1);
			sprintf(respuesta, "14/\n");
			write (socket_compa,respuesta,strlen(respuesta));
			
		break;
		case 8:
			p=strtok(NULL,"/");
			idpartida =atoi(p);
			p=strtok(NULL,"/");
			strcpy(invitado,p);
			printf(invitado);
			invitacionrespuesta(&milista,invitado,sock_conn,respuesta,idpartida);
			write (sock_conn,respuesta,strlen(respuesta));
		break;
		
		case 9:
			
			p=strtok(NULL,"/");
			char lider1[25];
			strcpy(lider1,p);
			printf(lider1);
			char companero[25];
			DameCompanero(&milista,lider1,companero);
			int socket_companero = DameSocket(&milista, companero);
			sprintf(respuesta, "13/\n");
			write (socket_companero,respuesta,strlen(respuesta));
			write (sock_conn, respuesta, strlen(respuesta));
			break;
		
		case 10:
			
			
			p=strtok(NULL,"/");
			char user1[25];
			strcpy(user1,p);
			p=strtok(NULL,"/");
			char chat[200];
			strcpy(chat,p);
			printf(user1);
			char user2[25];
			DameCompanero(&milista,user1,user2);
			char frase[512];
			sprintf(frase,"9/%s",chat);
			printf(user2);
			int socket1 = DameSocket(&milista, user1);
			int socket2 = DameSocket(&milista, user2);
			write (socket1,frase,strlen(frase));
			write (socket2,frase,strlen(frase));
			
			break;	
			
		case 11:
			p=strtok(NULL,"/");
			char r[20];
			strcpy(r, p);
			p=strtok(NULL,"/");
			char t[20];
			strcpy(t, p);
			EliminarUsuario(conn, respuesta, r, t, sock_conn);
			write(sock_conn, respuesta, strlen(respuesta));
			mostrarConectados(notificacion);
			for (int j = 0; j < milista.num; j++)
				write(milista.conectados[j].socket,notificacion,strlen(notificacion));
			break;
			break;
			
		case 12:
			
			p=strtok(NULL,"/");
			char usern1[25];
			char usern2[25];
			strcpy(usern1,p);
			DameCompanero(&milista,usern1,usern2);
			ReiniciarTabla();
			int sock1 = DameSocket(&milista,usern1);
			int sock2 = DameSocket(&milista,usern2);
			sprintf(respuesta, "15/");
			write(sock1, respuesta, strlen(respuesta));
			write(sock2, respuesta, strlen(respuesta));
			break;	
			
			
		case 15:
			p=strtok(NULL,"/");
			char username3[25];
			strcpy(username3,p);
			char companero3[25];
			DameCompanero(&milista,username3,companero3);
			int socket_companero3 = DameSocket(&milista, companero3);
			sprintf(respuesta, "16/\n");
			write (socket_companero3,respuesta,strlen(respuesta));
			write (sock_conn, respuesta, strlen(respuesta));
			break;
			break;
			
		case 16:
			printf("ganador\n");
			p=strtok(NULL,"/");
			char username4[25]; //perdedor
			strcpy(username4,p);
			char companero4[25];//ganador
			DameCompanero(&milista,username4,companero4);
			int socket_companero4 = DameSocket(&milista, companero4);
			sprintf(respuesta, "17/g"); //respuesta al ganador
			char respuesta2[512];
			sprintf(respuesta2, "17/p");//respuesta al perdedor
			write (socket_companero4,respuesta,strlen(respuesta));
			write (sock_conn, respuesta2, strlen(respuesta2));
			break;

			
	    default:
		break;
		}
	}
	mysql_close(conn);
	close(sock_conn);
}

int main(int argc, char *argv[]) {

	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	memset(&serv_adr, 0, sizeof(serv_adr));
	serv_adr.sin_family = AF_INET;
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	serv_adr.sin_port = htons(50022); //50022
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	if (listen(sock_listen, 15) < 0)
		printf("Error en el Listen");
	int i;
	int j;
	int sockets[100];
	pthread_t thread;
	i=0;
	
	for(;;) //per atendre totes les peticions que volguem
	{
		
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("conexion recibida\n");
		sockets[i] =sock_conn;
		pthread_create (&thread, NULL, atendercliente, &sockets[i]);
		i=i+1;
	}
	
}

