namespace EternalResolve.Common.Contents.Modulars.EternalResolveToolTipModular
{
    public class Line
    {
        public virtual int X { get; set; } = 0;

        public virtual int Y { get; set; } = 0;

        public virtual int Width { get; set; } = 0;

        public virtual int Height { get; set; } = 0;

        public virtual int DrawType { get; } = 0;

        public virtual void CheckSize( )
        {

        }

        public virtual void Draw( )
        {

        }

        public void SetSize( int width , int height )
        {
            Width = width;
            Height = height;
        }

        public void SetPosition( int x , int y )
        {
            X = x;
            Y = y;
        }
    }
}
