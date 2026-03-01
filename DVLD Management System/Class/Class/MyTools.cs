using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

 

namespace Dev_Note_Assistant
{

    /// <summary>
    ///  كلاس فيه ادوات تساعد على التحكم  بالعناصر وضبط شكلها 
    ///  وخواص ثانية مفيدة
    /// </summary>
    class MyTools
    {

        /// <summary>
        /// استدعاء الأيقونة من الموارد وتعيينها للفورم
        /// </summary>
        public static void SetFormIcon(Form form)
        {
          //  form.Icon = Properties.Resources.iconForm_Linky;
        }

        /// <summary>
        /// لجعل اطار العنصر ذو حواف ملتفة 
        /// </summary>
        /// <param name="ctrl">  العنصر </param>
        /// <param name="point"> 30  و افتراضياً تساوي    Point مقدار الالتفاف ب   </param>
        static public void FrameControl(Control ctrl, int point = 30)
        {
            GraphicsPath path = new GraphicsPath();
            // انشاء شكل مستطيل مع زاوية دائرية
            path.AddArc(0, 0, point, point, 180, 90);
            path.AddArc(ctrl.Width - point, 0, point, point, 270, 90);
            path.AddArc(ctrl.Width - point, ctrl.Height - point, point, point, 0, 90);
            path.AddArc(0, ctrl.Height - point, point, point, 90, 90);
            path.CloseFigure();
            ctrl.Region = new Region(path);
        }



        /// <summary>
        /// لجعل الواجهة قابلة للحركة بعد ازالة شريط عنوان الفورم
        /// </summary>
        /// <param name="ctrl"> العنصر  </param>
        public static void MoveControl(Control ctrl, Form frm)
        {

            Point mouseOffset = new Point(1, 1); ;
            bool isDragging = false;

            // حدث الضغط على العنصر
            ctrl.MouseDown += delegate (object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    isDragging = true;
                    mouseOffset = new Point(e.X, e.Y);

                }
            };

            // حدث الضغط وتحريك العنصر
            ctrl.MouseMove += delegate (object sender, MouseEventArgs e)
            {
                if (isDragging)
                {
                    int x = Cursor.Position.X - mouseOffset.X;
                    int y = Cursor.Position.Y - mouseOffset.Y;

                    frm.Location = new Point(x, y);
                }
            };

            //  حدث رفع الضغط على العنصر
            ctrl.MouseUp += delegate (object sender, MouseEventArgs e)
            {
                isDragging = false;
            };

        }

        /// <summary>
        ///       
        /// لتغيير لون الازرار الموجودة في البانل عند  مرور المؤشر فوقهم  funcktion  
        /// </summary>
        public static void EventColorButton(Panel panel)
        {
            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl is Button)
                {
                    ctrl.MouseEnter += delegate
                    {
                        ctrl.ForeColor = Color.Purple;
                        ctrl.BackColor = Color.LightCyan;
                    };
                    ctrl.MouseLeave += delegate
                    {
                        ctrl.ForeColor = Color.Navy;
                        ctrl.BackColor = Color.FromArgb(214, 234, 248);
                    };
                }

            }
        }


        /// <summary>
        ///       
        /// لتغيير لون العنصر عند مرور الزر فوقه 
        /// </summary>
        public static void EventColorControl(Control control)
        {

            control.MouseEnter += delegate
                    {
                        control.ForeColor = Color.Purple;
                        control.BackColor = Color.LightCyan;
                    };
            control.MouseLeave += delegate
                    {
                        control.ForeColor = Color.Navy;
                        control.BackColor = Color.FromArgb(214, 234, 248);
                    };
        }

        /// <summary>
        /// Panel لتغيير لون الازرار الموجودة داخل ال 
        /// </summary>
        /// <param name="panel"> Panel ال  </param>
        /// <param name="Font1">لون الخط الاساسي</param>
        /// <param name="Back1">لون الخلفية الاساسي</param>
        /// <param name="Font2">لون الخط عند  المرور</param>
        /// <param name="Back2">لون الخلفية عند المرور</param>
        public static void EventColorButton_InPanel(Panel panel, Color Font1, Color Back1, Color Font2, Color Back2)
        {
            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl is Button)
                {
                    ctrl.MouseEnter += delegate
                    {
                        ctrl.ForeColor = Font2;
                        ctrl.BackColor = Back2;
                    };
                    ctrl.MouseLeave += delegate
                    {
                        ctrl.ForeColor = Font1;
                        ctrl.BackColor = Back1;
                    };
                }
            }
        }

        /// <summary>
        /// عند مرور المؤشر فوقه  Panel  لتغيير لون  
        /// </summary>
        /// <param name="AllPanel">Panel قائمة ل </param>
        public static void EventColorPanels(List<Panel> AllPanel)
        {
            for (int index = 0; index < AllPanel.Count(); index++)
            {
                AllPanel[index].MouseEnter += delegate
                 {
                     AllPanel[index].ForeColor = Color.Purple;
                     AllPanel[index].BackColor = Color.LightCyan;
                 };
                AllPanel[index].MouseLeave += delegate
                 {
                     AllPanel[index].ForeColor = Color.Navy;
                     AllPanel[index].BackColor = Color.FromArgb(214, 234, 248);
                 };
            }
        }


        /// <summary>
        /// حتى يصلح لان يحوي على فورم  Panel ضبط ال
        /// </summary>
        /// <param name="pan">   الذي سيحوي على الفورم  Panel ال </param>
        /// <param name="frm"> Panel الفورم الذي سيكون داخل ال  </param>
        public static void SitingsPanel(Panel pan, Form frm)
        {
            // قم  بالغاء الشريط العلوي للفورم
            pan.Controls.Clear();
            frm.TopLevel = false;
            // frm.Dock = DockStyle.Fill;
            pan.Controls.Add(frm);
            frm.Show();
        }


        //  __ هي  X  احداثيات 
        /// <summary>
        /// فقط X يقوم بوضع العنصر في المنتصف ... للاحداثيات    
        /// </summary>
        /// <param name="Child">العنصر الابن</param>
        /// <param name="Parent">العنصر الأب .. الحاوي</param>
        /// <returns> X إرجاع  موقع احداثيات </returns>
        public static int LocationIn_Center_X(Control Child, Control Parent)
        {
            int Width_Parent = Parent.Width;
            int Width_Child = Child.Width;

            int Location_Y_Child = Child.Location.Y;

            int LocationCenterX = (Width_Parent - Width_Child) / 2;

            Child.Location = new Point(LocationCenterX, Location_Y_Child);

            return LocationCenterX;
        }

        /// <summary>
        /// فقط Y يقوم بوضع العنصر في المنتصف ... للاحداثيات    
        /// </summary>
        /// <param name="Child"></param>
        /// <param name="Parent"></param>
        /// <returns> Y إرجاع  موقع احداثيات </returns>
        public static int LocationIn_Center_Y(Control Child, Control Parent)
        {
            int Height_Parent = Parent.Height;
            int Height_Child = Child.Height;

            int Location_X_Child = Child.Location.X;

            int LocationCenterY = (Height_Parent - Height_Child) / 2;

            Child.Location = new Point(Location_X_Child, LocationCenterY);

            return LocationCenterY;
        }

        /// <summary>
        /// Y _ X  وضع العنصر في المنتصف في احداثيات 
        /// </summary>
        public static void LocationIn_Center_XY(Control Child, Control Parent)
        {
            LocationIn_Center_X(Child, Parent);
            LocationIn_Center_Y(Child, Parent);
        }


        /// <summary>
        /// فتح واجهة معينة إذا لم تكن مفتوحة، أو إظهارها إذا كانت موجودة.
        /// </summary>
        public static void ShowForm(Form frm)
        {
            // دور إذا الفورم نفسها موجودة ضمن OpenForms
            var openedForm = Application.OpenForms[frm.Name];

            if (openedForm == null)
            {
                // إذا مش موجودة → افتحها
                frm.Show();
            }
            else
            {
                // إذا موجودة → جيبها للأمام
                openedForm.BringToFront();
                openedForm.WindowState = FormWindowState.Normal;
            }
        }



        /// <summary>
        /// يرسم تدرج لوني على العنصر المحدد بشكل آمن
        /// </summary>
        /// <param name="control">العنصر (Form, Panel, Label ...)</param>
        /// <param name="color1">اللون الأول</param>
        /// <param name="color2">اللون الثاني</param>
        /// <param name="isBackground">True للخلفية، False للنص</param>
        public static void ColorControl(Control control, Color color1, Color color2, bool isBackground = true)
        {
            control.Paint += (s, e) =>
            {
                Rectangle rect = control.ClientRectangle;

                // تحقق من أن الحجم صالح قبل الرسم
                if (rect.Width <= 0 || rect.Height <= 0)
                    return;

                using (LinearGradientBrush brush = new LinearGradientBrush(
                    rect, color1, color2, LinearGradientMode.Vertical))
                {
                    if (isBackground)
                    {
                        e.Graphics.FillRectangle(brush, rect);
                    }
                    else
                    {
                        Font font = control.Font;
                        SizeF textSize = e.Graphics.MeasureString(control.Text, font);
                        PointF location = new PointF(
                            (control.Width - textSize.Width) / 2,
                            (control.Height - textSize.Height) / 2);

                        e.Graphics.DrawString(control.Text, font, brush, location);
                    }
                }
            };

            // إخفاء النص الأصلي إذا كنا نرسمه يدويًا
            if (!isBackground)
                control.ForeColor = Color.Transparent;

            // إعادة رسم العنصر بعد التعديل
            control.Invalidate();
        }





    }
}
