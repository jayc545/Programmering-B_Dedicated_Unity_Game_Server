﻿using System;
using System.Collections.Generic;
using System.Numerics;
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
            Server.clients[_fromClient].SendInToGame(_username);
        }

        public static void PlayerMovement( int _fromClient, Packet _packet)
        {
            bool[] _inputs = new bool[_packet.ReadInt()];

            for(int i = 0; i < _inputs.Length; i++)
            {
                _inputs[i] = _packet.ReadBool();
            }
            Quaternion _rotate = _packet.ReadQuaternion();

            Server.clients{ _fromClient}.player.SetInput(_inputs, _rotate);
        }
    }
}