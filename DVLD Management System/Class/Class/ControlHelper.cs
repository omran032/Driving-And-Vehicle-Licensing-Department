using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Management_System.Class.Class
{
    internal class ControlHelper
    {
        /// <summary>
        /// تفعيل تحديد الصف عند الضغط بزر اليمين على الـ DataGridView
        /// مع إظهار قائمة السياق وإرجاع رقم الصف المختار.
        /// </summary>
        public static void EnableRightClickSelection(DataGridView dgv, ContextMenuStrip menu, Action<int> onRowRightClick = null)
        {
            dgv.CellMouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
                {
                    dgv.ClearSelection();
                    dgv.Rows[e.RowIndex].Selected = true;
                  //  dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells[0];

                    dgv.ContextMenuStrip = menu;

                    onRowRightClick?.Invoke(e.RowIndex);
                }
                else
                {
                    dgv.ContextMenuStrip = null;
                }
            };
        }

        /// <summary>
        /// التحقق من إدخال العنصر
        /// </summary>
        public static bool IsNullTextBox(Control textBox , ErrorProvider provider , string Message = "هذا الحقل مطلوب")
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                provider.SetError(textBox, Message);
                return true;  // إنه فارغ
            }
            else
            {
                provider.SetError(textBox, null);
                return false; // ليس فارغ
            }
        }

        /// <summary>
        /// تفعيل أو إلغاء تفعيل منع إدخال الأحرف في TextBox، 
        /// بحيث يسمح فقط بالأرقام عند التفعيل.
        /// </summary>
        public static void EnableNumbersOnly(Control txt, bool enable)
        {
            txt.KeyPress -= Txt_KeyPress; // إزالة أي حدث سابق
            if (enable)
                txt.KeyPress += Txt_KeyPress; // إضافة الحدث فقط إذا enable = true
        }
        // حدث عند الكتابة
        private static void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                System.Media.SystemSounds.Hand.Play();
                e.Handled = true;
            }
        }


    }
}
