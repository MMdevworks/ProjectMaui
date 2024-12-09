using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Animations;

namespace ProjectMaui.Helpers
{
    public class FadeAnimation : BaseAnimation
    {
        public static readonly BindableProperty OpacityProperty =
            BindableProperty.Create(
                nameof(Opacity),
                typeof(double),
                typeof(FadeAnimation),
                0.3,
                BindingMode.TwoWay);
        // default duration 
        public FadeAnimation() : base(300)
        {
        }
        public double Opacity
        {
            get => (double)GetValue(OpacityProperty);
            set => SetValue(OpacityProperty, value);
        }

        public override async Task Animate(VisualElement view, CancellationToken token = default)
        {
            ArgumentNullException.ThrowIfNull(view);

            var originalOpacity = view.Opacity;

            await view.FadeTo(Opacity, Length, Easing).WaitAsync(token);
            await view.FadeTo(originalOpacity, Length, Easing).WaitAsync(token);
        }
    }
}
