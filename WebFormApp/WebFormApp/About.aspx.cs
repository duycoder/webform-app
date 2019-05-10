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
            //base.OnPreInit(e);
            //lblEventName.Text += "<br/>" + "PreInit";
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
            //lblEventName.Text = "Init<br/>";
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
            lblEventName.Text += "InitComplete<br/>";
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
        protected void Page_Preload(object sender, EventArgs e)
        {
            //lblEventName.Text += "Preload<br/>";
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
            //lblEventName.Text += "Load<br/>";
            if (!IsPostBack)
            {

                //sử dụng delegate
                //GetName gn = new GetName(GetNameById);
                //Sum sm = new Sum(GetSum);


                //TaxFormulas.TaxFormula salaryFormula = TaxFormulas.GetSalaryFormula("VN");
                //float vnSalary = 100000;

                //float tax = salaryFormula(vnSalary);

                //Response.Write(string.Format("Thuế tôi cần đóng đó là {0}", tax.ToString("c")));
                //LoadGender();

                //btnCommand.Command += new CommandEventHandler(btnCommand_Command);

                //Greeting greeting = new Greeting(VnGreeting);
                //greeting += new Greeting(UsaGreeting);
                //greeting += new Greeting(EuGreeting);

                //greeting("HELLO");


                //Action act = () => Response.Write("!!!!<br/>");
                //act = () => Response.Write("???<br/>");

                //act();

                //TaxFormulas.TaxFormula f = (float y) => (y * 100);

                //sử dụng elvis operator
                //People people = new People();
                //int? height = people?.Height;

                //int? otherHeight = (people == null) ? null : (int?)people.Height;

                //int? anotherHeight = (people?.Height) ?? 0;

                //List<People> gPeople = new List<People>();

                //int count = gPeople?[0].Orders?.Count() ?? 0;
            }
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
        protected void OnClickMe(object sender, EventArgs e)
        {
            //lblEventName.Text += "OnClickMe<br/>";
        }

        /*
         *- tạo ra sau khi các sự kiện "event handling"
         *- sử dụng sự kiện này cho các công việc cho các control
         * trên page sau khi được load
         */
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            //lblEventName.Text += "Load_Complete<br/>";
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
        protected void Page_PreRender(object sender, EventArgs e)
        {
            //lblEventName.Text += "OnPreRender<br/>";
        }

        /*
         * - sau khi state của page và các control đều đã được lưu
         * - tất cả các thay đổi của page và control đều được bỏ qua
         * - sử dụng sự kiện này để thực hiện tác vụ yêu cầu
         * viewstate được lưu lại nhưng không thay đổi gì các controls
         */
        protected void Page_SaveStateComplete(object sender, EventArgs e)
        {
            //lblEventName.Text += "OnSaveStateComplete<br/>";
        }

        /**
         * - sử dụng sự kiện này để clean code
         * - lúc này các object đều đã được load và an toàn để giải phóng tất cả tài
         * nguyên còn lại trong page hoặc kể cả page
         * - sẽ gọi hàm cleanup các controls sau đó đến page
         * - các contorols và page đều đã được render, vì thế sẽ không có
         * thay đổi nào được tạo ra trong luồng response
         * - nếu gọi hàm Response.Write hoặc hàm tương tự sẽ bắn ra "Exception"
         * 
         */
        protected void Page_UnLoad(object sender, EventArgs e)
        {
            //lblEventName.Text += "Unload<br/>";
        }

        protected void txtEventName_TextChanged(object sender, EventArgs e)
        {
            //lblEventName.Text = txtEventName.Text;
        }

        protected void btnSaveInfo_Clicked(object sender, EventArgs e)
        {
            Response.Write(rdbTech.SelectedItem.Value);
        }

        void LoadGender()
        {
            ListItem male = new ListItem("Nam", "1");
            ddlGender.Items.Add(male);

            ListItem female = new ListItem("Nữ", "2");
            ddlGender.Items.Add(female);
        }

        public delegate void Greeting(string input);

        public void VnGreeting(string input)
        {
            Response.Write($"VN: {input}<br/>");
        }

        public void UsaGreeting(string input)
        {
            Response.Write($"USA: {input}<br/>");
        }

        public void EuGreeting(string input)
        {
            Response.Write($"EUROPEAN: {input}<br/>");
        }


        protected void btnCommand_Command(object sender, CommandEventArgs e)
        {
            Response.Write("EVENT COMMAND EXECUTED");
        }

        public string SayHello(string firstName, string lastName)
        {
            //đây là kiểu hàm (string,string) -> string
            return "Hello " + firstName + " " + lastName;
        }

        public string SayHello(string firstName)
        {
            //đây là kiểu hàm (string) -> string
            return "Hello " + firstName;
        }

        public void Silent(string firstName)
        {
            //đây là kiểu hàm (string) -> ()
        }


        //cú pháp định nghĩa một delegate
        //delegate <return_type> <delegate_name> <parameter_list>

        private delegate int Sum(int numb1, int numb2);

        private delegate void GetNothing(int numb1, int numb2);

        private delegate string GetName(int id);

        public string GetNameById(int id)
        {
            return id.ToString();
        }

        public int GetSum(int a, int b)
        {
            return a + b;
        }


        public class TaxFormulas
        {
            //delegate đại diện cho các hàm (float) -> float
            public delegate float TaxFormula(float input);

            //công thức tính thuế của mỹ
            public static float UsaFormula(float salary)
            {
                return salary * 10 / 100;
            }

            //công thức tính thuế của việt nam
            public static float VnFormula(float salary)
            {
                return salary * 5 / 100;
            }

            public static float EuropeanFormula(float salary)
            {
                return salary * 8 / 100;
            }

            //trả về 1 hàm tính thuế dựa trên mã code
            public static TaxFormula GetSalaryFormula(string code)
            {
                if (code == "VN")
                {
                    return new TaxFormula(VnFormula);
                }
                else if (code == "US")
                {
                    return new TaxFormula(UsaFormula);
                }
                else if (code == "EU")
                {
                    return new TaxFormula(EuropeanFormula);
                }

                //trả về một delegate nặc danh có input
                //return delegate (float salary)
                //{
                //    return salary * 7 / 100;
                //};

                return (float salary) => salary * 7 / 100;

                //return (float salary) => salary * 7 / 100;
            }
        }

        public class Button
        {
            private string label;
            public delegate void ClickHandler(Button source, int x, int y);

            public event ClickHandler OnButtonClick;

            public Button(string label)
            {
                this.label = label;
            }

            public void Clicked()
            {
                Random random = new Random();
                int x = random.Next(1, 100);
                int y = random.Next(1, 20);

                if(OnButtonClick != null)
                {
                    OnButtonClick(this, x, y);
                }
            }

        }

        public class MyApplication
        {
            private Button openButton;
            private Button saveButton;
            private string fileName;
        }

        public class People
        {
            public int Height { get; set; }
            public List<Order> Orders { get; set; }
        }

        public class Order
        {
        }
    }
}