﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18444
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.ServiceReference, version 5.0.61118.0
// 
namespace Demo.WcfService {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="userinfo", Namespace="http://schemas.datacontract.org/2004/07/DAL.EF")]
    public partial class userinfo : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string creatorField;
        
        private string departField;
        
        private string emailField;
        
        private string mobileField;
        
        private string passwordField;
        
        private string realnameField;
        
        private string rolenameField;
        
        private string sexField;
        
        private string titleField;
        
        private string useridField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string creator {
            get {
                return this.creatorField;
            }
            set {
                if ((object.ReferenceEquals(this.creatorField, value) != true)) {
                    this.creatorField = value;
                    this.RaisePropertyChanged("creator");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string depart {
            get {
                return this.departField;
            }
            set {
                if ((object.ReferenceEquals(this.departField, value) != true)) {
                    this.departField = value;
                    this.RaisePropertyChanged("depart");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string email {
            get {
                return this.emailField;
            }
            set {
                if ((object.ReferenceEquals(this.emailField, value) != true)) {
                    this.emailField = value;
                    this.RaisePropertyChanged("email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string mobile {
            get {
                return this.mobileField;
            }
            set {
                if ((object.ReferenceEquals(this.mobileField, value) != true)) {
                    this.mobileField = value;
                    this.RaisePropertyChanged("mobile");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string password {
            get {
                return this.passwordField;
            }
            set {
                if ((object.ReferenceEquals(this.passwordField, value) != true)) {
                    this.passwordField = value;
                    this.RaisePropertyChanged("password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string realname {
            get {
                return this.realnameField;
            }
            set {
                if ((object.ReferenceEquals(this.realnameField, value) != true)) {
                    this.realnameField = value;
                    this.RaisePropertyChanged("realname");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string rolename {
            get {
                return this.rolenameField;
            }
            set {
                if ((object.ReferenceEquals(this.rolenameField, value) != true)) {
                    this.rolenameField = value;
                    this.RaisePropertyChanged("rolename");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string sex {
            get {
                return this.sexField;
            }
            set {
                if ((object.ReferenceEquals(this.sexField, value) != true)) {
                    this.sexField = value;
                    this.RaisePropertyChanged("sex");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string title {
            get {
                return this.titleField;
            }
            set {
                if ((object.ReferenceEquals(this.titleField, value) != true)) {
                    this.titleField = value;
                    this.RaisePropertyChanged("title");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string userid {
            get {
                return this.useridField;
            }
            set {
                if ((object.ReferenceEquals(this.useridField, value) != true)) {
                    this.useridField = value;
                    this.RaisePropertyChanged("userid");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.baidu.com", ConfigurationName="WcfService.WcfService")]
    public interface WcfService {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.baidu.com/WcfService/login", ReplyAction="http://www.baidu.com/WcfService/loginResponse")]
        System.IAsyncResult Beginlogin(string name, string pwd, System.AsyncCallback callback, object asyncState);
        
        Demo.WcfService.userinfo Endlogin(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.baidu.com/WcfService/AddUser", ReplyAction="http://www.baidu.com/WcfService/AddUserResponse")]
        System.IAsyncResult BeginAddUser(System.AsyncCallback callback, object asyncState);
        
        void EndAddUser(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.baidu.com/WcfService/UpdateUser", ReplyAction="http://www.baidu.com/WcfService/UpdateUserResponse")]
        System.IAsyncResult BeginUpdateUser(System.AsyncCallback callback, object asyncState);
        
        void EndUpdateUser(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.baidu.com/WcfService/GetUser", ReplyAction="http://www.baidu.com/WcfService/GetUserResponse")]
        System.IAsyncResult BeginGetUser(System.AsyncCallback callback, object asyncState);
        
        void EndGetUser(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.baidu.com/WcfService/DelUser", ReplyAction="http://www.baidu.com/WcfService/DelUserResponse")]
        System.IAsyncResult BeginDelUser(System.AsyncCallback callback, object asyncState);
        
        void EndDelUser(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WcfServiceChannel : Demo.WcfService.WcfService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class loginCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public loginCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public Demo.WcfService.userinfo Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((Demo.WcfService.userinfo)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WcfServiceClient : System.ServiceModel.ClientBase<Demo.WcfService.WcfService>, Demo.WcfService.WcfService {
        
        private BeginOperationDelegate onBeginloginDelegate;
        
        private EndOperationDelegate onEndloginDelegate;
        
        private System.Threading.SendOrPostCallback onloginCompletedDelegate;
        
        private BeginOperationDelegate onBeginAddUserDelegate;
        
        private EndOperationDelegate onEndAddUserDelegate;
        
        private System.Threading.SendOrPostCallback onAddUserCompletedDelegate;
        
        private BeginOperationDelegate onBeginUpdateUserDelegate;
        
        private EndOperationDelegate onEndUpdateUserDelegate;
        
        private System.Threading.SendOrPostCallback onUpdateUserCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetUserDelegate;
        
        private EndOperationDelegate onEndGetUserDelegate;
        
        private System.Threading.SendOrPostCallback onGetUserCompletedDelegate;
        
        private BeginOperationDelegate onBeginDelUserDelegate;
        
        private EndOperationDelegate onEndDelUserDelegate;
        
        private System.Threading.SendOrPostCallback onDelUserCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public WcfServiceClient() {
        }
        
        public WcfServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WcfServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WcfServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WcfServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("无法设置 CookieContainer。请确保绑定包含 HttpCookieContainerBindingElement。");
                }
            }
        }
        
        public event System.EventHandler<loginCompletedEventArgs> loginCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> AddUserCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> UpdateUserCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> GetUserCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> DelUserCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult Demo.WcfService.WcfService.Beginlogin(string name, string pwd, System.AsyncCallback callback, object asyncState) {
            return base.Channel.Beginlogin(name, pwd, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Demo.WcfService.userinfo Demo.WcfService.WcfService.Endlogin(System.IAsyncResult result) {
            return base.Channel.Endlogin(result);
        }
        
        private System.IAsyncResult OnBeginlogin(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string name = ((string)(inValues[0]));
            string pwd = ((string)(inValues[1]));
            return ((Demo.WcfService.WcfService)(this)).Beginlogin(name, pwd, callback, asyncState);
        }
        
        private object[] OnEndlogin(System.IAsyncResult result) {
            Demo.WcfService.userinfo retVal = ((Demo.WcfService.WcfService)(this)).Endlogin(result);
            return new object[] {
                    retVal};
        }
        
        private void OnloginCompleted(object state) {
            if ((this.loginCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.loginCompleted(this, new loginCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void loginAsync(string name, string pwd) {
            this.loginAsync(name, pwd, null);
        }
        
        public void loginAsync(string name, string pwd, object userState) {
            if ((this.onBeginloginDelegate == null)) {
                this.onBeginloginDelegate = new BeginOperationDelegate(this.OnBeginlogin);
            }
            if ((this.onEndloginDelegate == null)) {
                this.onEndloginDelegate = new EndOperationDelegate(this.OnEndlogin);
            }
            if ((this.onloginCompletedDelegate == null)) {
                this.onloginCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnloginCompleted);
            }
            base.InvokeAsync(this.onBeginloginDelegate, new object[] {
                        name,
                        pwd}, this.onEndloginDelegate, this.onloginCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult Demo.WcfService.WcfService.BeginAddUser(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginAddUser(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void Demo.WcfService.WcfService.EndAddUser(System.IAsyncResult result) {
            base.Channel.EndAddUser(result);
        }
        
        private System.IAsyncResult OnBeginAddUser(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((Demo.WcfService.WcfService)(this)).BeginAddUser(callback, asyncState);
        }
        
        private object[] OnEndAddUser(System.IAsyncResult result) {
            ((Demo.WcfService.WcfService)(this)).EndAddUser(result);
            return null;
        }
        
        private void OnAddUserCompleted(object state) {
            if ((this.AddUserCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.AddUserCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void AddUserAsync() {
            this.AddUserAsync(null);
        }
        
        public void AddUserAsync(object userState) {
            if ((this.onBeginAddUserDelegate == null)) {
                this.onBeginAddUserDelegate = new BeginOperationDelegate(this.OnBeginAddUser);
            }
            if ((this.onEndAddUserDelegate == null)) {
                this.onEndAddUserDelegate = new EndOperationDelegate(this.OnEndAddUser);
            }
            if ((this.onAddUserCompletedDelegate == null)) {
                this.onAddUserCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnAddUserCompleted);
            }
            base.InvokeAsync(this.onBeginAddUserDelegate, null, this.onEndAddUserDelegate, this.onAddUserCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult Demo.WcfService.WcfService.BeginUpdateUser(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginUpdateUser(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void Demo.WcfService.WcfService.EndUpdateUser(System.IAsyncResult result) {
            base.Channel.EndUpdateUser(result);
        }
        
        private System.IAsyncResult OnBeginUpdateUser(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((Demo.WcfService.WcfService)(this)).BeginUpdateUser(callback, asyncState);
        }
        
        private object[] OnEndUpdateUser(System.IAsyncResult result) {
            ((Demo.WcfService.WcfService)(this)).EndUpdateUser(result);
            return null;
        }
        
        private void OnUpdateUserCompleted(object state) {
            if ((this.UpdateUserCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.UpdateUserCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void UpdateUserAsync() {
            this.UpdateUserAsync(null);
        }
        
        public void UpdateUserAsync(object userState) {
            if ((this.onBeginUpdateUserDelegate == null)) {
                this.onBeginUpdateUserDelegate = new BeginOperationDelegate(this.OnBeginUpdateUser);
            }
            if ((this.onEndUpdateUserDelegate == null)) {
                this.onEndUpdateUserDelegate = new EndOperationDelegate(this.OnEndUpdateUser);
            }
            if ((this.onUpdateUserCompletedDelegate == null)) {
                this.onUpdateUserCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnUpdateUserCompleted);
            }
            base.InvokeAsync(this.onBeginUpdateUserDelegate, null, this.onEndUpdateUserDelegate, this.onUpdateUserCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult Demo.WcfService.WcfService.BeginGetUser(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetUser(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void Demo.WcfService.WcfService.EndGetUser(System.IAsyncResult result) {
            base.Channel.EndGetUser(result);
        }
        
        private System.IAsyncResult OnBeginGetUser(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((Demo.WcfService.WcfService)(this)).BeginGetUser(callback, asyncState);
        }
        
        private object[] OnEndGetUser(System.IAsyncResult result) {
            ((Demo.WcfService.WcfService)(this)).EndGetUser(result);
            return null;
        }
        
        private void OnGetUserCompleted(object state) {
            if ((this.GetUserCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetUserCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetUserAsync() {
            this.GetUserAsync(null);
        }
        
        public void GetUserAsync(object userState) {
            if ((this.onBeginGetUserDelegate == null)) {
                this.onBeginGetUserDelegate = new BeginOperationDelegate(this.OnBeginGetUser);
            }
            if ((this.onEndGetUserDelegate == null)) {
                this.onEndGetUserDelegate = new EndOperationDelegate(this.OnEndGetUser);
            }
            if ((this.onGetUserCompletedDelegate == null)) {
                this.onGetUserCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetUserCompleted);
            }
            base.InvokeAsync(this.onBeginGetUserDelegate, null, this.onEndGetUserDelegate, this.onGetUserCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult Demo.WcfService.WcfService.BeginDelUser(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginDelUser(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void Demo.WcfService.WcfService.EndDelUser(System.IAsyncResult result) {
            base.Channel.EndDelUser(result);
        }
        
        private System.IAsyncResult OnBeginDelUser(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((Demo.WcfService.WcfService)(this)).BeginDelUser(callback, asyncState);
        }
        
        private object[] OnEndDelUser(System.IAsyncResult result) {
            ((Demo.WcfService.WcfService)(this)).EndDelUser(result);
            return null;
        }
        
        private void OnDelUserCompleted(object state) {
            if ((this.DelUserCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.DelUserCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void DelUserAsync() {
            this.DelUserAsync(null);
        }
        
        public void DelUserAsync(object userState) {
            if ((this.onBeginDelUserDelegate == null)) {
                this.onBeginDelUserDelegate = new BeginOperationDelegate(this.OnBeginDelUser);
            }
            if ((this.onEndDelUserDelegate == null)) {
                this.onEndDelUserDelegate = new EndOperationDelegate(this.OnEndDelUser);
            }
            if ((this.onDelUserCompletedDelegate == null)) {
                this.onDelUserCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnDelUserCompleted);
            }
            base.InvokeAsync(this.onBeginDelUserDelegate, null, this.onEndDelUserDelegate, this.onDelUserCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override Demo.WcfService.WcfService CreateChannel() {
            return new WcfServiceClientChannel(this);
        }
        
        private class WcfServiceClientChannel : ChannelBase<Demo.WcfService.WcfService>, Demo.WcfService.WcfService {
            
            public WcfServiceClientChannel(System.ServiceModel.ClientBase<Demo.WcfService.WcfService> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult Beginlogin(string name, string pwd, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[2];
                _args[0] = name;
                _args[1] = pwd;
                System.IAsyncResult _result = base.BeginInvoke("login", _args, callback, asyncState);
                return _result;
            }
            
            public Demo.WcfService.userinfo Endlogin(System.IAsyncResult result) {
                object[] _args = new object[0];
                Demo.WcfService.userinfo _result = ((Demo.WcfService.userinfo)(base.EndInvoke("login", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginAddUser(System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[0];
                System.IAsyncResult _result = base.BeginInvoke("AddUser", _args, callback, asyncState);
                return _result;
            }
            
            public void EndAddUser(System.IAsyncResult result) {
                object[] _args = new object[0];
                base.EndInvoke("AddUser", _args, result);
            }
            
            public System.IAsyncResult BeginUpdateUser(System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[0];
                System.IAsyncResult _result = base.BeginInvoke("UpdateUser", _args, callback, asyncState);
                return _result;
            }
            
            public void EndUpdateUser(System.IAsyncResult result) {
                object[] _args = new object[0];
                base.EndInvoke("UpdateUser", _args, result);
            }
            
            public System.IAsyncResult BeginGetUser(System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[0];
                System.IAsyncResult _result = base.BeginInvoke("GetUser", _args, callback, asyncState);
                return _result;
            }
            
            public void EndGetUser(System.IAsyncResult result) {
                object[] _args = new object[0];
                base.EndInvoke("GetUser", _args, result);
            }
            
            public System.IAsyncResult BeginDelUser(System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[0];
                System.IAsyncResult _result = base.BeginInvoke("DelUser", _args, callback, asyncState);
                return _result;
            }
            
            public void EndDelUser(System.IAsyncResult result) {
                object[] _args = new object[0];
                base.EndInvoke("DelUser", _args, result);
            }
        }
    }
}
