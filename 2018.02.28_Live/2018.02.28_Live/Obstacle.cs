﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018._02._28_Live
{
    class Obstacle : Cell
    {
        
        public Obstacle(char image = '#')
            : base(image)
        {
        }

        public Obstacle(Coordinate z) 
            : base(z)
        {
            _image = Ocean.OBSTACLEIMAGE;
        }
    }
}
