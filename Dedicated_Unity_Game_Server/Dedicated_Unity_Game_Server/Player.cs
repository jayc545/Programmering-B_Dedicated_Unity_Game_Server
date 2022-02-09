﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace Dedicated_Unity_Game_Server
{
    public class Player
    {
        public int id;
        public string username;

        public Vector3 position;
        public Quaternion rotation;

        private float moveSpeed = 5f / Constants.TICKS_PER_SEC;
        private bool[] inputs;



        public Player( int _id, string _username, Vector3 _spawnPosition)
        {
            id = _id;
            username = _username;
            position = _spawnPosition;
            rotation = Quaternion.Identity;
        }

        public void Update()
        {
            Vector2 _inputdirection = Vector2.Zero;
            if (inputs[0])
            {
                _inputdirection.Y += 1;
            }
            if (inputs[1])
            {
                _inputdirection.Y += 1;
            }
            if (inputs[2])
            {
                _inputdirection.X += 1;
            }
            if (inputs[3])
            {
                _inputdirection.X += 1;
            }

            Move(_inputdirection);
        }

        private void Move(Vector2 _inputDirection)
        {
            Vector3 _forward = Vector3.Transform(new Vector3(0, 0, 1), rotation);
            Vector3 _right = Vector3.Normalize(Vector3.Cross(_forward, new Vector3(0, 1, 0)));

            Vector3 _moveDirection = _right * _inputDirection.X + _forward * _inputDirection.Y;
            position += _moveDirection * moveSpeed;

            ServerSend.PlayerPosition(this);
            ServerSend.Rotation(this);
        }


        public void SetInput(bool[] _inputs, Quaternion _rotation)
        {
            inputs = _inputs;
            rotation = _rotation;
        }
    }
}
