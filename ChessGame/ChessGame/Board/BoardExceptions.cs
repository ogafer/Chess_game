﻿using System;

namespace board
{
    class BoardExceptions : Exception
    {
        public BoardExceptions (string error) : base(error) { }
    }
}
