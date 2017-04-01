using Microsoft.AspNet.Mvc.Facebook;

// 添加你想要为每个用户保存的所有字段，并指定从 Facebook 返回的 JSON 中的字段名
// http://go.microsoft.com/fwlink/?LinkId=301877

namespace TestWeb.Models
{
    public class MyAppUserFriend
    {
        public string Name { get; set; }
        public string Link { get; set; }

        [FacebookFieldModifier("height(100).width(100)")] // 这会将图片高度和宽度设置为 100px。
        public FacebookConnection<FacebookPicture> Picture { get; set; }
    }
}
