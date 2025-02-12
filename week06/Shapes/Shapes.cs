using System;

namespace Shapes 
{
    
    class abstract Shapes 
    {

        private string _color;

        public GetColor() 
        {
            return _color;
        }

        public SetColor(string color)
        {
            _color = color;
        }

        public abstract GetArea();

    }
}