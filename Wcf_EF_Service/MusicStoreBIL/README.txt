###MusicStoreBIL###
MusicStoreBIL工程是整个web应用的业务逻辑层，主要提供了：
1.Dao数据访问
2.基础的组件服务（非WCF服务，参考Spring中的模式）
这儿存在架构设计问题，因为我没有对dao进行service的封装而直接应用在了WCF服务中
