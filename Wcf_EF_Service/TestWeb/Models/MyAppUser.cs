using Microsoft.AspNet.Mvc.Facebook;
using Newtonsoft.Json;

// 添加你想要为每个用户保存的所有字段，并指定从 Facebook 返回的 JSON 中的字段名
// http://go.microsoft.com/fwlink/?LinkId=301877

namespace TestWeb.Models
{
    public class MyAppUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [JsonProperty("picture")] // 这会将属性重命名为 picture。
        [FacebookFieldModifier("type(large)")] // 这会将图片大小设置为 large。
        public FacebookConnection<FacebookPicture> ProfilePicture { get; set; }

        [FacebookFieldModifier("limit(8)")] // 这会将好友列表的大小设置为 8，删除它可获取所有好友。
        public FacebookGroupConnection<MyAppUserFriend> Friends { get; set; }

        [FacebookFieldModifier("limit(16)")] // 这会将照片列表的大小设置为 16，删除它可获取所有照片。
        public FacebookGroupConnection<FacebookPhoto> Photos { get; set; }
    }
}
