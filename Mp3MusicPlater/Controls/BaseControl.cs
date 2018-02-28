using Mp3.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Mp3MusicPlater
{
    public class BaseControl : UserControl
    {
        #region Field
        private ControlAnimation _animationStatus = ControlAnimation.ToFirstPosition;

        private float _slideSecont = 0.4F; 
        #endregion
        
        #region Property
        public ControlAnimation AnimationStatus
        {
            get { return _animationStatus; }
            set { _animationStatus = value; }
        }

        public float SlideSecont
        {
            get { return _slideSecont; }
            set { _slideSecont = value; }
        } 
        #endregion

        #region Animation

        public async Task Animation(ControlAnimation animationType)
        {
            if (animationType == ControlAnimation.None)
                return;
            if (IoC.Get<ApplicationViewModel>().SlideFromRightToLeft)
                await AnimateToLeftSide(animationType);
            else
                await AnimateToRightSide(animationType);
        }

        private async Task AnimateToRightSide(ControlAnimation animationType)
        {
            switch(animationType)
            {
                case ControlAnimation.ToThirdPosition:
                    await this.SlideFromLeftToFirstPosision(this._slideSecont);
                    break;
                case ControlAnimation.ToSecondPosition:
                    await this.SlideFromThirdPosisionToSecondPosisionAndGrowUp(this._slideSecont);
                    break;
                case ControlAnimation.ToFirstPosition:
                    await this.SlideFromCenterPosisionToPosisionOnRightAndReduce(this.SlideSecont);
                    break;
                case ControlAnimation.ToZeroPosition:
                    await this.SlideOutToRight(this.SlideSecont);
                    break;

            }
            animationType--;
        }

        private async Task AnimateToLeftSide(ControlAnimation animationType)
        {
            
            switch (animationType)
            {
                case ControlAnimation.ToFirstPosition:
                    await this.SlideFromRightToFirstPosision(this._slideSecont);
                    break;
                case ControlAnimation.ToSecondPosition:
                    await this.SlideFromFirstPosisionToSecondPosisionAndGrowUp(this._slideSecont);
                    break;
                case ControlAnimation.ToThirdPosition:
                    await this.SlideFromCenterPosisionToPosisionOnLeftAndReduce(this.SlideSecont);
                    break;
                case ControlAnimation.ToFourthPosition:
                    await this.SlideOutToLeft(this.SlideSecont);
                    break;
            } 
            
        } 

        #endregion

        #region Constructor
        public BaseControl()
        {
            this.Loaded += BaseControl_Loaded;
        }


        #endregion

        #region Private Helper

        async void BaseControl_Loaded(object sender, System.Windows.RoutedEventArgs e) => await Animation(this.AnimationStatus);

        #endregion
    }

    public class BaseControl<VM> : BaseControl
        where VM : BaseViewModel, new()
    {
        #region Fields

        private VM _ViewModel; 

        #endregion

        #region Property

        public VM ViewModel
        {
            get { return _ViewModel; }
            set 
            {
                if (_ViewModel == value)
                    return;

                _ViewModel = value;

                this.DataContext = _ViewModel;
            
            }
        } 

        #endregion

        #region Constructor

        public BaseControl() : base()
        {
            this.ViewModel = new VM();
        }

        #endregion

    }
}
