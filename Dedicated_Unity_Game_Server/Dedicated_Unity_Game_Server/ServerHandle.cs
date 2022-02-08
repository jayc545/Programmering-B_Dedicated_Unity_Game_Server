using System;
using System.Collections.Generic;
using System.Text;

namespace Dedicated_Unity_Game_Server
{
    class ServerHandle
    {
        public static void WellcomeReceived(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _username = _packet.ReadString();

            Console.WriteLine($"{Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} connected succesfully and is now player {_fromClient}.");
            if (_fromClient != _clientIdCheck)
            {
                Console.WriteLine($"Player \"{_username}\" (ID: { _fromClient}) has assumed the wrong client ID ({_clientIdCheck})!");
            }
            // TODO: Send player into game.
        }
    }
}