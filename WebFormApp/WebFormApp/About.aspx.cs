using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormApp
{
    public partial class About : Page
    {
        /*
         *- tạo hoặc tái tạo dynamic control
         *- cài đặt master page hoặc theme linh động
         *- kiểm tra thuộc tính IsPostBack xem có phải là lần đầu trang được xử lý không?
         *- nếu request là một PostBack thì giá trị của các control chưa được
         * lấy ra từ "viewstate".nếu thiết lập thuộc tính control trong này nó
         * có thể bị ghi đè trong các sự kiện sau đó
         * 
         */
        protected void Page_PreInit(object sender, EventArgs e)
        {

        }

        /*
         * - sự kiện xảy ra sau khi tất cả các control được khởi tạo
         * - sử dụng sự kiện này để tạo các thuộc tính của controls (control property)
         * - the init event is fired first for the bottom-first control 
         * in hierachy, and then fired up the hierachy until it is
         * fired for the page itself
         * 
         */
        protected void Page_Init(object sender, EventArgs e)
        {

        }

        /*
         *- tại sự kiện này các giá trị viewstate vẫn chưa được tải lên, vì thế
         * có thể sử dụng sự kiện này để thay đổi viewstate mà bạn muốn
         * đảm bảo chúng "persisted" chắc chắn
         * - được gọi bởi Page object
         * - sử dụng sự kiện này để chạy các quy trình yêu cầu toàn bộ các thành phần được load
         */
        protected void Page_InitComplete(object sender, EventArgs e)
        {
            
        }

        /*
         * - xảy ra sau khi page có viewstate cho nó và tất cả controls,
         * và sau khi nó xử lý "postback data" 
         * - trước khi page xử chạy sự kiện này, nó tải viewstate của nó
         * và tất cả các controls, sau đó xử lý tất cả các dữ liệu 
         * postback được gửi bởi một thực thể "Request"
         * - tải viewstate về các control
         * - tải dữ liệu postback: dữ liệu postback được quản lý bởi các "controls"
         */
        protected void OnPreLoad(object sender, EventArgs e)
        {

        }

        /*
         * - Page controls gọi hàm này sau đó gọi đệ quy hàm load của tất
         * cả các "control" con bên trong nó cho đến khi tất cả các control đều đã
         * được load. Sự kiện load của các control xảy ra sau khi sự kiện load của trang
         * cha được hoàn thành
         * - mọi giá trị khi vào hàm này đều được restored
         * - hầu hết check IsPostBack để đảm bảo việc "reset state" không được gọi bừa bãi
         */
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /*
         *- sự kiện xảy ra trên các control tạo ra sự kiện postback trên page
         *- sử dụng hàm để quản lý cá sự kiện control trên page
         *- trong postback request, nếu page có các control validate
         * kiểm tra page và các contro validator có "IsValid" hay không
         * trước khi tiếp tục xử lý
         * 
         * 
         */

        /*
         *- tạo ra sau khi các sự kiện "event handling"
         *- sử dụng sự kiện này cho các công việc cho các control
         * trên page sau khi được load
         */
        protected void Load_Complete(object sender, EventArgs e)
        {

        }

        /*
         *- sau khi tất cả các control cần thiết cho page được tạo ra
         *- page sau khi gọi hàm này sẽ gọi hàm tương tự của các controls
         * theo phương thức đệ quy
         * - cho phép thực hiện thay đổi lần cuối cho page và các controls
         * - sự kiện này xảy ra trước khi ViewState được lưu, vì thế tất cả
         * các thay đổi ở đây đều được lưu lại
         * - mỗi một control có ràng buộc dữ liệu có thuộc tính DataSourceID
         * gán đều gọi đến phương thức DataBind()
         * - sử dụng sự kiện để lưu các thay đổi cuối cùng cho nội dung
         * của page và controls trong page
         */
        protected void OnPreRender(object sender, EventArgs e)
        {

        }
    }
}