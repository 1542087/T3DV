namespace BackEnd
{
    class TestCallDll
    {
        public NganHang MethodReturnObject()
        {
            NganHang nh = new NganHang();
            nh.MaNH = "NH0001";
            nh.TenNH = "Asia Commercial Joint Stock Bank";
            nh.LoaiNH = "ACB";
            return nh;

        }
        public string MethodReturnString()
        {
            return "aaaa";

        }
    }
    public class NganHang
    {
      
        public string MaNH { get; set; }
        public string TenNH { get; set; }
        public string LoaiNH { get; set; }
    }
}
