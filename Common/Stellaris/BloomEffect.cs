using Microsoft.Xna.Framework.Graphics;

namespace EternalResolve.Common.Stellaris
{
    public class BloomEffect : Effect
    {
        internal BloomEffect( GraphicsDevice graphicsDevice , byte[ ] _code ) : base( graphicsDevice , _code )
        {
        }

        internal BloomEffect( Effect cloneResource ) : base( cloneResource )
        {
        }

        public EffectParameter WorkTexture
        {
            get
            {
                return base.Parameters[ "OperateTex" ];
            }
        }

        public EffectParameter OriginTexture
        {
            get
            {
                return base.Parameters[ "MainTex" ];
            }
        }

        public EffectParameter XYRatio
        {
            get
            {
                return base.Parameters[ "XYRatio" ];
            }
        }

        public EffectParameter BlurRadius
        {
            get
            {
                return base.Parameters[ "Radius" ];
            }
        }

        public EffectParameter BloomIntensity
        {
            get
            {
                return base.Parameters[ "BloomIntensity" ];
            }
        }

        public EffectParameter RaySampleDensity
        {
            get
            {
                return base.Parameters[ "Density" ];
            }
        }

        public EffectParameter LightDecay
        {
            get
            {
                return base.Parameters[ "Decay" ];
            }
        }

        public EffectParameter RayWeight
        {
            get
            {
                return base.Parameters[ "Weight" ];
            }
        }

        public EffectParameter RayIntensity
        {
            get
            {
                return base.Parameters[ "RayIntensity" ];
            }
        }

        public EffectParameter LightSourceCoord
        {
            get
            {
                return base.Parameters[ "LightSourceCoord" ];
            }
        }

        public void InitDefaultValue( )
        {
            BlurRadius.SetValue( 0.0035f );
            BloomIntensity.SetValue( 1f );
            RaySampleDensity.SetValue( 2f );
            LightDecay.SetValue( 0.95f );
            RayWeight.SetValue( 1f );
            RayIntensity.SetValue( 0.2f );
        }

        public void ApplyLuminanceFilter( )
        {
            base.Techniques[ 0 ].Passes[ 0 ].Apply( );
        }

        public void ApplyBlurX( )
        {
            base.Techniques[ 0 ].Passes[ 1 ].Apply( );
        }

        public void ApplyBlurY( )
        {
            base.Techniques[ 0 ].Passes[ 2 ].Apply( );
        }

        public void ApplyMixTwoImage( )
        {
            base.Techniques[ 0 ].Passes[ 3 ].Apply( );
        }

        public void ApplyGodRay( )
        {
            base.Techniques[ 0 ].Passes[ 4 ].Apply( );
        }
    }
}
