using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace UI.Controls
{
    /// <summary>
    /// Describes one icon-and-label item shown by <see cref="TopBarButtonsControl"/>.
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class TopBarButtonItem : INotifyPropertyChanged
    {
        private string _key = string.Empty;
        private string _text = string.Empty;
        private string _imageKey = string.Empty;
        private Image _image;
        private bool _visible = true;
        private bool _enabled = true;
        private object _tag;

        public TopBarButtonItem()
        {
        }

        public TopBarButtonItem(string key, string text, string imageKey)
        {
            Key = key;
            Text = text;
            ImageKey = imageKey;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets an application-defined identifier for the item.
        /// </summary>
        [Category("Data")]
        [Description("An application-defined identifier for the item.")]
        [DefaultValue("")]
        public string Key
        {
            get { return _key; }
            set { SetField(ref _key, value ?? string.Empty, "Key"); }
        }

        /// <summary>
        /// Gets or sets the caption displayed below the icon.
        /// </summary>
        [Category("Appearance")]
        [Description("The caption displayed below the icon.")]
        [DefaultValue("")]
        public string Text
        {
            get { return _text; }
            set { SetField(ref _text, value ?? string.Empty, "Text"); }
        }

        /// <summary>
        /// Gets or sets a DevExpress image resource key, for example
        /// "images/navigation/home_32x32.png". The DevExpress image cache resolves the key.
        /// </summary>
        [Category("Appearance")]
        [Description("A DevExpress image resource key resolved through ImageResourceCache.")]
        [DefaultValue("")]
        public string ImageKey
        {
            get { return _imageKey; }
            set { SetField(ref _imageKey, value ?? string.Empty, "ImageKey"); }
        }

        /// <summary>
        /// Gets or sets a custom image. The control does not dispose images assigned here.
        /// </summary>
        [Category("Appearance")]
        [Description("An optional custom image. The caller owns and disposes this image.")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Image Image
        {
            get { return _image; }
            set { SetField(ref _image, value, "Image"); }
        }

        [Category("Behavior")]
        [Description("Determines whether the item participates in the navigation bar layout.")]
        [DefaultValue(true)]
        public bool Visible
        {
            get { return _visible; }
            set { SetField(ref _visible, value, "Visible"); }
        }

        [Category("Behavior")]
        [Description("Determines whether the item can be clicked.")]
        [DefaultValue(true)]
        public bool Enabled
        {
            get { return _enabled; }
            set { SetField(ref _enabled, value, "Enabled"); }
        }

        [Category("Data")]
        [Description("Optional application-defined data associated with the item.")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object Tag
        {
            get { return _tag; }
            set { SetField(ref _tag, value, "Tag"); }
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(_text) ? base.ToString() : _text;
        }

        private void SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return;

            field = value;

            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
