#PythontTCPServerTester
#Wordt gebruikt om informatie te ontvangen van de C# client

import socket
import sys
from _thread import *

#Server Information
host = '127.0.0.1'
port = 5555
s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

#Bind Port
try:
    s.bind((host, port))
    print("Socket Created! Server Info: " + host + ":" + str(port))
except socket.error as e:
    print(str(e))

#Start listening for Clients
s.listen(5)
print("Awaiting client connection")

#Start thread for client connection
def threaded_client(conn):
    conn.send(str.encode("You've successfully connected to the EV3 TCP Server"))
    print("Message Sent!")
    while True:
        data = conn.recv(2048)
        if not data:
            break
        print(data)
    conn.close()

#Accept Clients and execute threaded_client
while True:

    conn, addr = s.accept()
    print("connected to: "+addr[0]+":"+str(addr[1]))

    start_new_thread(threaded_client,(conn,))