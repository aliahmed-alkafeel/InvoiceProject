using DevExpress.Images;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace UI.Controls
{
    /// <summary>
    /// A compact horizontal navigation bar with icon-and-label items, painted in a
    /// traditional WinForms toolbar style. The control is self-contained and does not
    /// perform navigation or business operations; consumers handle <see cref="ItemClick"/>.
    /// </summary>
    [ToolboxItem(true)]
    [DefaultProperty("Items")]
    [DefaultEvent("SelectedItemChanged")]
    [Description("A compact horizontal navigation bar with icon-and-label items.")]
    public partial class TopBarButtonsControl : XtraUserControl
    {
        private readonly TopBarButtonItemCollection _items;
        private readonly Color _disabledForeColor = Color.FromArgb(158, 166, 174);

        private TopBarButtonItem _selectedItem;
        private int _hoverIndex = -1;
        private int _pressedIndex = -1;
        private int _itemWidth = 104;
        private int _minimumItemWidth = 72;
        private int _iconSize = 26;
        private bool _showSeparators = true;
        private bool _selectOnClick = true;
        private bool _updatingScrollExtent;

        private Color _selectedBackColor = Color.FromArgb(220, 236, 250);
        private Color _selectedBorderColor = Color.FromArgb(141, 190, 226);
        private Color _selectedForeColor = Color.FromArgb(24, 75, 120);
        private Color _hoverBackColor = Color.FromArgb(243, 248, 253);
        private Color _pressedBackColor = Color.FromArgb(231, 242, 252);
        private Color _separatorColor = Color.FromArgb(225, 230, 235);
        private Color _borderColor = Color.FromArgb(214, 220, 226);

        public TopBarButtonsControl()
        {
            InitializeComponent();

            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.Selectable,
                true);
            UpdateStyles();

            _items = new TopBarButtonItemCollection(this);
            BackColor = Color.FromArgb(250, 251, 252);
            TabStop = true;
            AccessibleName = "Navigation";
            AccessibleRole = AccessibleRole.ToolBar;
        }

        /// <summary>
        /// Raised when an item is clicked or activated from the keyboard.
        /// </summary>
        [Category("Action")]
        [Description("Raised when an item is clicked or activated from the keyboard.")]
        public event EventHandler<TopBarButtonItemEventArgs> ItemClick;

        /// <summary>
        /// Raised after the selected item changes.
        /// </summary>
        [Category("Behavior")]
        [Description("Raised after the selected item changes.")]
        public event EventHandler<TopBarButtonItemEventArgs> SelectedItemChanged;

        /// <summary>
        /// Gets the navigation items. Add, remove, or reorder items through this collection.
        /// </summary>
        [Category("Data")]
        [Description("The navigation items displayed by the control.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TopBarButtonItemCollection Items
        {
            get { return _items; }
        }

        /// <summary>
        /// Gets or sets the index of the selected item. Returns -1 when nothing is selected.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get { return _selectedItem == null ? -1 : _items.IndexOf(_selectedItem); }
            set { SetSelectedIndex(value, true); }
        }

        /// <summary>
        /// Gets or sets the selected item. Set to null to clear the selection.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TopBarButtonItem SelectedItem
        {
            get { return _selectedItem; }
            set { SetSelectedItem(value, true); }
        }

        /// <summary>
        /// Gets or sets the key of the selected item. Set to null or an empty string to clear
        /// the selection. If the key is not found, the selection is cleared.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedKey
        {
            get { return _selectedItem == null ? string.Empty : _selectedItem.Key; }
            set { SelectItem(value); }
        }

        /// <summary>
        /// Gets or sets the preferred width of one item in pixels. The control reduces this
        /// value when the available width is insufficient.
        /// </summary>
        [Category("Layout")]
        [Description("The preferred width of one navigation item in pixels.")]
        [DefaultValue(104)]
        public int ItemWidth
        {
            get { return _itemWidth; }
            set
            {
                int newValue = Math.Max(1, value);
                if (_itemWidth == newValue)
                    return;

                _itemWidth = newValue;
                UpdateScrollExtent();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the smallest width an item may shrink to before horizontal scrolling
        /// is used.
        /// </summary>
        [Category("Layout")]
        [Description("The minimum item width in pixels before horizontal scrolling is used.")]
        [DefaultValue(72)]
        public int MinimumItemWidth
        {
            get { return _minimumItemWidth; }
            set
            {
                int newValue = Math.Max(1, value);
                if (_minimumItemWidth == newValue)
                    return;

                _minimumItemWidth = newValue;
                UpdateScrollExtent();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the icon size in pixels. Set to 0 to hide icons.
        /// </summary>
        [Category("Appearance")]
        [Description("The icon size in pixels. Set to 0 to hide icons.")]
        [DefaultValue(26)]
        public int IconSize
        {
            get { return _iconSize; }
            set
            {
                int newValue = Math.Max(0, Math.Min(128, value));
                if (_iconSize == newValue)
                    return;

                _iconSize = newValue;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Determines whether subtle vertical separators are drawn between items.")]
        [DefaultValue(true)]
        public bool ShowSeparators
        {
            get { return _showSeparators; }
            set
            {
                if (_showSeparators == value)
                    return;

                _showSeparators = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets whether clicking an item changes the selection. When false, the
        /// control only raises <see cref="ItemClick"/>.
        /// </summary>
        [Category("Behavior")]
        [Description("Determines whether clicking an item changes the selected item.")]
        [DefaultValue(true)]
        public bool SelectOnClick
        {
            get { return _selectOnClick; }
            set { _selectOnClick = value; }
        }

        [Category("Appearance")]
        [Description("The background color of the selected item.")]
        public Color SelectedBackColor
        {
            get { return _selectedBackColor; }
            set { SetColor(ref _selectedBackColor, value); }
        }

        [Category("Appearance")]
        [Description("The border color of the selected item.")]
        public Color SelectedBorderColor
        {
            get { return _selectedBorderColor; }
            set { SetColor(ref _selectedBorderColor, value); }
        }

        [Category("Appearance")]
        [Description("The text color of the selected item.")]
        public Color SelectedForeColor
        {
            get { return _selectedForeColor; }
            set { SetColor(ref _selectedForeColor, value); }
        }

        [Category("Appearance")]
        [Description("The background color of a hovered item.")]
        public Color HoverBackColor
        {
            get { return _hoverBackColor; }
            set { SetColor(ref _hoverBackColor, value); }
        }

        [Category("Appearance")]
        [Description("The background color of a pressed item.")]
        public Color PressedBackColor
        {
            get { return _pressedBackColor; }
            set { SetColor(ref _pressedBackColor, value); }
        }

        [Category("Appearance")]
        [Description("The color of the separator lines between items.")]
        public Color SeparatorColor
        {
            get { return _separatorColor; }
            set { SetColor(ref _separatorColor, value); }
        }

        [Category("Appearance")]
        [Description("The color of the control's outer top and bottom border.")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set { SetColor(ref _borderColor, value); }
        }

        /// <summary>
        /// Adds an item and returns it.
        /// </summary>
        public TopBarButtonItem AddItem(string key, string text, string imageKey)
        {
            TopBarButtonItem item = new TopBarButtonItem(key, text, imageKey);
            Items.Add(item);
            return item;
        }

        /// <summary>
        /// Selects the first item with the supplied key. Pass null or an empty string to
        /// clear the selection.
        /// </summary>
        public void SelectItem(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                SelectedItem = null;
                return;
            }

            for (int i = 0; i < _items.Count; i++)
            {
                if (string.Equals(_items[i].Key, key, StringComparison.OrdinalIgnoreCase))
                {
                    SelectedIndex = i;
                    return;
                }
            }

            SelectedItem = null;
        }

        /// <summary>
        /// Selects the supplied item, which must belong to this control.
        /// </summary>
        public void SelectItem(TopBarButtonItem item)
        {
            if (item != null && !_items.Contains(item))
            {
                throw new ArgumentException(
                    "The item does not belong to this control.",
                    "item");
            }

            SelectedItem = item;
        }

        /// <summary>
        /// Removes all items.
        /// </summary>
        public void ClearItems()
        {
            Items.Clear();
        }

        /// <summary>
        /// Recalculates the scroll extent and repaints the control after changes to items
        /// made outside the item property change notifications.
        /// </summary>
        public void RefreshItems()
        {
            UpdateScrollExtent();
            Invalidate();
        }

        /// <summary>
        /// Applies visibility flags using a caller-supplied predicate. This replaces the
        /// original control's role-specific ApplyRoles method without coupling the control
        /// to the application's user or role model.
        /// </summary>
        public void ApplyVisibility(Func<TopBarButtonItem, bool> isVisible)
        {
            if (isVisible == null)
                throw new ArgumentNullException("isVisible");

            for (int i = 0; i < _items.Count; i++)
                _items[i].Visible = isVisible(_items[i]);

            RefreshItems();
        }

        internal void NotifyItemsChanged()
        {
            if (_selectedItem != null && !_items.Contains(_selectedItem))
                SetSelectedItem(null, true);

            _hoverIndex = -1;
            _pressedIndex = -1;
            UpdateScrollExtent();
            Invalidate();
        }

        internal void NotifyItemChanged(TopBarButtonItem item, string propertyName)
        {
            if (propertyName == "Visible")
            {
                _hoverIndex = -1;
                _pressedIndex = -1;
                UpdateScrollExtent();
            }

            Invalidate();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.None;

            DrawOuterBorder(g);

            int itemWidth = GetItemWidth();
            int itemHeight = GetItemHeight();
            if (itemWidth <= 0 || itemHeight <= 0)
                return;

            int lastVisibleIndex = GetLastVisibleIndex();
            int x = Padding.Left + AutoScrollPosition.X;
            int y = Padding.Top;

            for (int i = 0; i < _items.Count; i++)
            {
                TopBarButtonItem item = _items[i];
                if (!item.Visible)
                    continue;

                Rectangle itemBounds = new Rectangle(x, y, itemWidth, itemHeight);
                bool selected = ReferenceEquals(item, _selectedItem);
                bool hovered = i == _hoverIndex;
                bool pressed = i == _pressedIndex;

                DrawItemBackground(g, itemBounds, item.Enabled, selected, hovered, pressed);
                DrawItemContent(g, itemBounds, item, selected);

                if (_showSeparators && i != lastVisibleIndex)
                    DrawSeparator(g, itemBounds);

                x += itemWidth;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateScrollExtent();
            Invalidate();
        }

        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
            UpdateScrollExtent();
            Invalidate();
        }

        protected override bool IsInputKey(Keys keyData)
        {
            Keys key = keyData & Keys.KeyCode;
            if (key == Keys.Left || key == Keys.Right || key == Keys.Home || key == Keys.End)
                return true;

            return base.IsInputKey(keyData);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Handled)
                return;

            switch (e.KeyCode)
            {
                case Keys.Left:
                    MoveSelection(-1);
                    e.Handled = true;
                    break;
                case Keys.Right:
                    MoveSelection(1);
                    e.Handled = true;
                    break;
                case Keys.Home:
                    SelectEdgeItem(true);
                    e.Handled = true;
                    break;
                case Keys.End:
                    SelectEdgeItem(false);
                    e.Handled = true;
                    break;
                case Keys.Enter:
                case Keys.Space:
                    if (_selectedItem != null)
                        ActivateItem(_items.IndexOf(_selectedItem));
                    e.Handled = true;
                    break;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            int index = HitTestItem(e.Location);
            if (index == _hoverIndex)
                return;

            _hoverIndex = index;

            TopBarButtonItem item = index >= 0 ? _items[index] : null;
            Cursor = item != null && item.Enabled ? Cursors.Hand : Cursors.Default;

            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button != MouseButtons.Left)
                return;

            Focus();

            int index = HitTestItem(e.Location);
            _pressedIndex = index >= 0 && _items[index].Enabled ? index : -1;

            if (_pressedIndex >= 0)
                Capture = true;

            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.Button != MouseButtons.Left)
                return;

            int index = HitTestItem(e.Location);
            bool activate = index >= 0 && index == _pressedIndex;

            _pressedIndex = -1;
            if (Capture)
                Capture = false;

            Invalidate();

            if (activate)
                ActivateItem(index);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            _hoverIndex = -1;
            if (!Capture)
                _pressedIndex = -1;

            Cursor = Cursors.Default;
            Invalidate();
        }

        protected override void OnMouseCaptureChanged(EventArgs e)
        {
            base.OnMouseCaptureChanged(e);

            if (!Capture)
            {
                _pressedIndex = -1;
                Invalidate();
            }
        }

        private void DrawOuterBorder(Graphics g)
        {
            using (Pen pen = new Pen(_borderColor))
            {
                g.DrawLine(pen, 0, 0, ClientSize.Width, 0);
                g.DrawLine(pen, 0, ClientSize.Height - 1, ClientSize.Width, ClientSize.Height - 1);
            }
        }

        private void DrawItemBackground(
            Graphics g,
            Rectangle bounds,
            bool enabled,
            bool selected,
            bool hovered,
            bool pressed)
        {
            Color fillColor = Color.Empty;

            if (selected)
                fillColor = _selectedBackColor;
            else if (pressed && enabled)
                fillColor = _pressedBackColor;
            else if (hovered && enabled)
                fillColor = _hoverBackColor;

            if (fillColor != Color.Empty)
            {
                using (SolidBrush brush = new SolidBrush(fillColor))
                    g.FillRectangle(brush, bounds);
            }

            if (selected)
            {
                using (Pen pen = new Pen(_selectedBorderColor))
                {
                    g.DrawRectangle(
                        pen,
                        bounds.Left,
                        bounds.Top,
                        Math.Max(0, bounds.Width - 1),
                        Math.Max(0, bounds.Height - 1));
                }
            }
        }

        private void DrawItemContent(
            Graphics g,
            Rectangle itemBounds,
            TopBarButtonItem item,
            bool selected)
        {
            int labelHeight = TextRenderer.MeasureText("Ag", Font).Height;
            int iconSize = GetFittedIconSize(itemBounds, labelHeight);
            int gap = iconSize > 0 ? 2 : 0;
            int contentHeight = iconSize + gap + labelHeight;
            int contentTop = itemBounds.Top + Math.Max(0, (itemBounds.Height - contentHeight) / 2);

            if (iconSize > 0)
            {
                Rectangle iconBounds = new Rectangle(
                    itemBounds.Left + (itemBounds.Width - iconSize) / 2,
                    contentTop,
                    iconSize,
                    iconSize);

                DrawItemIcon(g, item, iconBounds);
                contentTop += iconSize + gap;
            }

            Rectangle labelBounds = new Rectangle(
                itemBounds.Left + 3,
                contentTop,
                Math.Max(0, itemBounds.Width - 6),
                labelHeight);

            Color foreColor = !item.Enabled
                ? _disabledForeColor
                : selected ? _selectedForeColor : ForeColor;

            TextRenderer.DrawText(
                g,
                item.Text,
                Font,
                labelBounds,
                foreColor,
                TextFormatFlags.HorizontalCenter |
                TextFormatFlags.VerticalCenter |
                TextFormatFlags.SingleLine |
                TextFormatFlags.EndEllipsis |
                TextFormatFlags.NoPrefix);
        }

        private void DrawItemIcon(Graphics g, TopBarButtonItem item, Rectangle bounds)
        {
            Image image = GetItemImage(item);
            if (image == null)
            {
                DrawFallbackIcon(g, bounds, item.Enabled);
                return;
            }

            InterpolationMode oldInterpolationMode = g.InterpolationMode;
            PixelOffsetMode oldPixelOffsetMode = g.PixelOffsetMode;

            try
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawImage(image, bounds);
            }
            finally
            {
                g.InterpolationMode = oldInterpolationMode;
                g.PixelOffsetMode = oldPixelOffsetMode;
            }
        }

        private static Image GetItemImage(TopBarButtonItem item)
        {
            if (item.Image != null)
                return item.Image;

            if (string.IsNullOrEmpty(item.ImageKey))
                return null;

            try
            {
                return ImageResourceCache.Default.GetImage(item.ImageKey);
            }
            catch (Exception)
            {
                // A missing or invalid image key must not prevent the control from painting.
                return null;
            }
        }

        private void DrawFallbackIcon(Graphics g, Rectangle bounds, bool enabled)
        {
            if (bounds.Width < 8 || bounds.Height < 8)
                return;

            Color color = enabled
                ? Color.FromArgb(118, 130, 143)
                : _disabledForeColor;

            SmoothingMode oldSmoothingMode = g.SmoothingMode;

            try
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                using (Pen pen = new Pen(color, 1.4f))
                {
                    Rectangle page = new Rectangle(
                        bounds.Left + bounds.Width / 4,
                        bounds.Top + bounds.Height / 8,
                        Math.Max(1, bounds.Width / 2),
                        Math.Max(1, bounds.Height * 3 / 4));

                    g.DrawRectangle(pen, page);
                    g.DrawLine(pen, page.Left + 3, page.Top + 5, page.Right - 3, page.Top + 5);
                    g.DrawLine(pen, page.Left + 3, page.Top + 9, page.Right - 3, page.Top + 9);
                }
            }
            finally
            {
                g.SmoothingMode = oldSmoothingMode;
            }
        }

        private void DrawSeparator(Graphics g, Rectangle itemBounds)
        {
            int top = itemBounds.Top + 8;
            int bottom = itemBounds.Bottom - 8;
            if (bottom <= top)
                return;

            int x = itemBounds.Right - 1;

            using (Pen pen = new Pen(_separatorColor))
                g.DrawLine(pen, x, top, x, bottom);
        }

        private int GetFittedIconSize(Rectangle itemBounds, int labelHeight)
        {
            int configuredIconSize = ScaleValue(_iconSize);
            if (configuredIconSize <= 0)
                return 0;

            int availableHeight = itemBounds.Height - labelHeight - 6;
            int availableWidth = itemBounds.Width - 8;
            int size = Math.Min(configuredIconSize, Math.Min(availableHeight, availableWidth));

            return Math.Max(0, size);
        }

        private int GetItemWidth()
        {
            int count = GetVisibleItemCount();
            if (count <= 0)
                return 0;

            int preferred = Math.Max(1, ScaleValue(_itemWidth));
            int minimum = Math.Max(1, Math.Min(ScaleValue(_minimumItemWidth), preferred));
            int available = ClientSize.Width - Padding.Horizontal;

            if (available <= 0)
                return minimum;

            int width = available / count;
            if (width > preferred)
                width = preferred;
            if (width < minimum)
                width = minimum;

            return width;
        }

        private int GetItemHeight()
        {
            return Math.Max(0, ClientSize.Height - Padding.Vertical);
        }

        private int ScaleValue(int value)
        {
            return (int)Math.Round(value * (DeviceDpi / 96f));
        }

        private int GetVisibleItemCount()
        {
            if (_items == null)
                return 0;

            int count = 0;
            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].Visible)
                    count++;
            }

            return count;
        }

        private int GetLastVisibleIndex()
        {
            if (_items == null)
                return -1;

            for (int i = _items.Count - 1; i >= 0; i--)
            {
                if (_items[i].Visible)
                    return i;
            }

            return -1;
        }

        private int HitTestItem(Point point)
        {
            int itemWidth = GetItemWidth();
            int itemHeight = GetItemHeight();
            if (itemWidth <= 0 || itemHeight <= 0)
                return -1;

            int x = Padding.Left + AutoScrollPosition.X;
            int y = Padding.Top;

            for (int i = 0; i < _items.Count; i++)
            {
                if (!_items[i].Visible)
                    continue;

                Rectangle itemBounds = new Rectangle(x, y, itemWidth, itemHeight);
                if (itemBounds.Contains(point))
                    return i;

                x += itemWidth;
            }

            return -1;
        }

        private void MoveSelection(int direction)
        {
            if (GetVisibleItemCount() == 0)
                return;

            int current = SelectedIndex;
            if (current < 0)
            {
                SelectEdgeItem(direction > 0);
                return;
            }

            int index = current;
            for (int step = 0; step < _items.Count; step++)
            {
                index = (index + direction + _items.Count) % _items.Count;
                if (_items[index].Visible)
                {
                    SelectedIndex = index;
                    return;
                }
            }
        }

        private void SelectEdgeItem(bool first)
        {
            if (first)
            {
                for (int i = 0; i < _items.Count; i++)
                {
                    if (_items[i].Visible)
                    {
                        SelectedIndex = i;
                        return;
                    }
                }
            }
            else
            {
                for (int i = _items.Count - 1; i >= 0; i--)
                {
                    if (_items[i].Visible)
                    {
                        SelectedIndex = i;
                        return;
                    }
                }
            }
        }

        private void ActivateItem(int index)
        {
            if (index < 0 || index >= _items.Count)
                return;

            TopBarButtonItem item = _items[index];
            if (!item.Visible || !item.Enabled)
                return;

            if (_selectOnClick)
                SelectedItem = item;

            OnItemClick(item);
        }

        private void SetSelectedIndex(int index, bool raiseEvent)
        {
            if (index < -1 || index >= _items.Count)
                throw new ArgumentOutOfRangeException("index");

            TopBarButtonItem item = index >= 0 ? _items[index] : null;
            SetSelectedItem(item, raiseEvent);
        }

        private void SetSelectedItem(TopBarButtonItem item, bool raiseEvent)
        {
            if (item != null && !_items.Contains(item))
                throw new ArgumentException("The item does not belong to this control.", "item");

            if (ReferenceEquals(_selectedItem, item))
                return;

            _selectedItem = item;
            Invalidate();

            if (raiseEvent)
                OnSelectedItemChanged(item);
        }

        private void OnSelectedItemChanged(TopBarButtonItem item)
        {
            EventHandler<TopBarButtonItemEventArgs> handler = SelectedItemChanged;
            if (handler != null)
                handler(this, new TopBarButtonItemEventArgs(item));
        }

        private void OnItemClick(TopBarButtonItem item)
        {
            EventHandler<TopBarButtonItemEventArgs> handler = ItemClick;
            if (handler != null)
                handler(this, new TopBarButtonItemEventArgs(item));
        }

        private void UpdateScrollExtent()
        {
            if (_updatingScrollExtent || _items == null)
                return;

            _updatingScrollExtent = true;

            try
            {
                int width = Padding.Horizontal + GetVisibleItemCount() * GetItemWidth();
                Size desiredSize = new Size(width, 0);

                if (AutoScrollMinSize != desiredSize)
                    AutoScrollMinSize = desiredSize;
            }
            finally
            {
                _updatingScrollExtent = false;
            }
        }

        private void SetColor(ref Color field, Color value)
        {
            if (field == value)
                return;

            field = value;
            Invalidate();
        }
    }

    /// <summary>
    /// Event data for <see cref="TopBarButtonsControl.ItemClick"/> and
    /// <see cref="TopBarButtonsControl.SelectedItemChanged"/>.
    /// </summary>
    public class TopBarButtonItemEventArgs : EventArgs
    {
        public TopBarButtonItemEventArgs(TopBarButtonItem item)
        {
            Item = item;
        }

        /// <summary>
        /// Gets the item associated with the event. Can be null when the selection is cleared.
        /// </summary>
        public TopBarButtonItem Item { get; private set; }
    }

    /// <summary>
    /// A collection of navigation items that notifies its owning control about changes.
    /// </summary>
    public class TopBarButtonItemCollection : Collection<TopBarButtonItem>
    {
        private readonly TopBarButtonsControl _owner;

        internal TopBarButtonItemCollection(TopBarButtonsControl owner)
        {
            _owner = owner;
        }

        protected override void InsertItem(int index, TopBarButtonItem item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            base.InsertItem(index, item);
            item.PropertyChanged += OnItemPropertyChanged;
            _owner.NotifyItemsChanged();
        }

        protected override void SetItem(int index, TopBarButtonItem item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            TopBarButtonItem oldItem = this[index];
            if (ReferenceEquals(oldItem, item))
                return;

            oldItem.PropertyChanged -= OnItemPropertyChanged;
            base.SetItem(index, item);
            item.PropertyChanged += OnItemPropertyChanged;
            _owner.NotifyItemsChanged();
        }

        protected override void RemoveItem(int index)
        {
            TopBarButtonItem item = this[index];
            item.PropertyChanged -= OnItemPropertyChanged;
            base.RemoveItem(index);
            _owner.NotifyItemsChanged();
        }

        protected override void ClearItems()
        {
            for (int i = 0; i < Count; i++)
                this[i].PropertyChanged -= OnItemPropertyChanged;

            base.ClearItems();
            _owner.NotifyItemsChanged();
        }

        private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _owner.NotifyItemChanged((TopBarButtonItem)sender, e.PropertyName);
        }
    }
}
