﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFClient.MusicStoreReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Album", Namespace="www.ranran.MusicStoreWcfRest")]
    [System.SerializableAttribute()]
    public partial class Album : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AlbumArtUrlField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AlbumIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ArtistIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int GenreIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal PriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AlbumArtUrl {
            get {
                return this.AlbumArtUrlField;
            }
            set {
                if ((object.ReferenceEquals(this.AlbumArtUrlField, value) != true)) {
                    this.AlbumArtUrlField = value;
                    this.RaisePropertyChanged("AlbumArtUrl");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int AlbumId {
            get {
                return this.AlbumIdField;
            }
            set {
                if ((this.AlbumIdField.Equals(value) != true)) {
                    this.AlbumIdField = value;
                    this.RaisePropertyChanged("AlbumId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ArtistId {
            get {
                return this.ArtistIdField;
            }
            set {
                if ((this.ArtistIdField.Equals(value) != true)) {
                    this.ArtistIdField = value;
                    this.RaisePropertyChanged("ArtistId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int GenreId {
            get {
                return this.GenreIdField;
            }
            set {
                if ((this.GenreIdField.Equals(value) != true)) {
                    this.GenreIdField = value;
                    this.RaisePropertyChanged("GenreId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Price {
            get {
                return this.PriceField;
            }
            set {
                if ((this.PriceField.Equals(value) != true)) {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="www.ranran.MusicStoreWcfRest", ConfigurationName="MusicStoreReference.IWCFAlbumService")]
    public interface IWCFAlbumService {
        
        [System.ServiceModel.OperationContractAttribute(Action="www.ranran.MusicStoreWcfRest/IWCFAlbumService/FindAll", ReplyAction="www.ranran.MusicStoreWcfRest/IWCFAlbumService/FindAllResponse")]
        WCFClient.MusicStoreReference.Album[] FindAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="www.ranran.MusicStoreWcfRest/IWCFAlbumService/FindAll", ReplyAction="www.ranran.MusicStoreWcfRest/IWCFAlbumService/FindAllResponse")]
        System.Threading.Tasks.Task<WCFClient.MusicStoreReference.Album[]> FindAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="www.ranran.MusicStoreWcfRest/IWCFAlbumService/FindOne", ReplyAction="www.ranran.MusicStoreWcfRest/IWCFAlbumService/FindOneResponse")]
        WCFClient.MusicStoreReference.Album FindOne(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="www.ranran.MusicStoreWcfRest/IWCFAlbumService/FindOne", ReplyAction="www.ranran.MusicStoreWcfRest/IWCFAlbumService/FindOneResponse")]
        System.Threading.Tasks.Task<WCFClient.MusicStoreReference.Album> FindOneAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="www.ranran.MusicStoreWcfRest/IWCFAlbumService/Create", ReplyAction="www.ranran.MusicStoreWcfRest/IWCFAlbumService/CreateResponse")]
        WCFClient.MusicStoreReference.Album Create(WCFClient.MusicStoreReference.Album album);
        
        [System.ServiceModel.OperationContractAttribute(Action="www.ranran.MusicStoreWcfRest/IWCFAlbumService/Create", ReplyAction="www.ranran.MusicStoreWcfRest/IWCFAlbumService/CreateResponse")]
        System.Threading.Tasks.Task<WCFClient.MusicStoreReference.Album> CreateAsync(WCFClient.MusicStoreReference.Album album);
        
        [System.ServiceModel.OperationContractAttribute(Action="www.ranran.MusicStoreWcfRest/IWCFAlbumService/Update", ReplyAction="www.ranran.MusicStoreWcfRest/IWCFAlbumService/UpdateResponse")]
        WCFClient.MusicStoreReference.Album Update(WCFClient.MusicStoreReference.Album album);
        
        [System.ServiceModel.OperationContractAttribute(Action="www.ranran.MusicStoreWcfRest/IWCFAlbumService/Update", ReplyAction="www.ranran.MusicStoreWcfRest/IWCFAlbumService/UpdateResponse")]
        System.Threading.Tasks.Task<WCFClient.MusicStoreReference.Album> UpdateAsync(WCFClient.MusicStoreReference.Album album);
        
        [System.ServiceModel.OperationContractAttribute(Action="www.ranran.MusicStoreWcfRest/IWCFAlbumService/Delete", ReplyAction="www.ranran.MusicStoreWcfRest/IWCFAlbumService/DeleteResponse")]
        void Delete(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="www.ranran.MusicStoreWcfRest/IWCFAlbumService/Delete", ReplyAction="www.ranran.MusicStoreWcfRest/IWCFAlbumService/DeleteResponse")]
        System.Threading.Tasks.Task DeleteAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="www.ranran.MusicStoreWcfRest/IWCFAlbumService/search", ReplyAction="www.ranran.MusicStoreWcfRest/IWCFAlbumService/searchResponse")]
        WCFClient.MusicStoreReference.Album[] search(int genreId, string title, decimal minPrice, decimal maxPrice);
        
        [System.ServiceModel.OperationContractAttribute(Action="www.ranran.MusicStoreWcfRest/IWCFAlbumService/search", ReplyAction="www.ranran.MusicStoreWcfRest/IWCFAlbumService/searchResponse")]
        System.Threading.Tasks.Task<WCFClient.MusicStoreReference.Album[]> searchAsync(int genreId, string title, decimal minPrice, decimal maxPrice);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWCFAlbumServiceChannel : WCFClient.MusicStoreReference.IWCFAlbumService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WCFAlbumServiceClient : System.ServiceModel.ClientBase<WCFClient.MusicStoreReference.IWCFAlbumService>, WCFClient.MusicStoreReference.IWCFAlbumService {
        
        public WCFAlbumServiceClient() {
        }
        
        public WCFAlbumServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WCFAlbumServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WCFAlbumServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WCFAlbumServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WCFClient.MusicStoreReference.Album[] FindAll() {
            return base.Channel.FindAll();
        }
        
        public System.Threading.Tasks.Task<WCFClient.MusicStoreReference.Album[]> FindAllAsync() {
            return base.Channel.FindAllAsync();
        }
        
        public WCFClient.MusicStoreReference.Album FindOne(string id) {
            return base.Channel.FindOne(id);
        }
        
        public System.Threading.Tasks.Task<WCFClient.MusicStoreReference.Album> FindOneAsync(string id) {
            return base.Channel.FindOneAsync(id);
        }
        
        public WCFClient.MusicStoreReference.Album Create(WCFClient.MusicStoreReference.Album album) {
            return base.Channel.Create(album);
        }
        
        public System.Threading.Tasks.Task<WCFClient.MusicStoreReference.Album> CreateAsync(WCFClient.MusicStoreReference.Album album) {
            return base.Channel.CreateAsync(album);
        }
        
        public WCFClient.MusicStoreReference.Album Update(WCFClient.MusicStoreReference.Album album) {
            return base.Channel.Update(album);
        }
        
        public System.Threading.Tasks.Task<WCFClient.MusicStoreReference.Album> UpdateAsync(WCFClient.MusicStoreReference.Album album) {
            return base.Channel.UpdateAsync(album);
        }
        
        public void Delete(string id) {
            base.Channel.Delete(id);
        }
        
        public System.Threading.Tasks.Task DeleteAsync(string id) {
            return base.Channel.DeleteAsync(id);
        }
        
        public WCFClient.MusicStoreReference.Album[] search(int genreId, string title, decimal minPrice, decimal maxPrice) {
            return base.Channel.search(genreId, title, minPrice, maxPrice);
        }
        
        public System.Threading.Tasks.Task<WCFClient.MusicStoreReference.Album[]> searchAsync(int genreId, string title, decimal minPrice, decimal maxPrice) {
            return base.Channel.searchAsync(genreId, title, minPrice, maxPrice);
        }
    }
}
