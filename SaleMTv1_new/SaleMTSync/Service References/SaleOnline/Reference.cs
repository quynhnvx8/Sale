﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SaleMTSync.SaleOnline {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BusinessException", Namespace="http://webservice.viettel.com/")]
    [System.SerializableAttribute()]
    public partial class BusinessException : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://webservice.viettel.com/", ConfigurationName="SaleOnline.GetExportDataWs")]
    public interface GetExportDataWs {
        
        // CODEGEN: Parameter 'arg0' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        SaleMTSync.SaleOnline.deleteFileResponse deleteFile(SaleMTSync.SaleOnline.deleteFile request);
        
        // CODEGEN: Parameter 'return' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        SaleMTSync.SaleOnline.uploadFileResponse uploadFile(SaleMTSync.SaleOnline.uploadFile request);
        
        // CODEGEN: Parameter 'return' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(SaleMTSync.SaleOnline.BusinessException), Action="", Name="BusinessException")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        SaleMTSync.SaleOnline.getLastVersionResponse getLastVersion(SaleMTSync.SaleOnline.getLastVersion request);
        
        // CODEGEN: Parameter 'return' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        SaleMTSync.SaleOnline.getUpdateDataResponse getUpdateData(SaleMTSync.SaleOnline.getUpdateData request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="deleteFile", WrapperNamespace="http://webservice.viettel.com/", IsWrapped=true)]
    public partial class deleteFile {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://webservice.viettel.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string arg0;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://webservice.viettel.com/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string arg1;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://webservice.viettel.com/", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute("arg2", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string[] arg2;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://webservice.viettel.com/", Order=3)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string arg3;
        
        public deleteFile() {
        }
        
        public deleteFile(string arg0, string arg1, string[] arg2, string arg3) {
            this.arg0 = arg0;
            this.arg1 = arg1;
            this.arg2 = arg2;
            this.arg3 = arg3;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="deleteFileResponse", WrapperNamespace="http://webservice.viettel.com/", IsWrapped=true)]
    public partial class deleteFileResponse {
        
        public deleteFileResponse() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="uploadFile", WrapperNamespace="http://webservice.viettel.com/", IsWrapped=true)]
    public partial class uploadFile {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://webservice.viettel.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string arg0;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://webservice.viettel.com/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string arg1;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://webservice.viettel.com/", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string arg2;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://webservice.viettel.com/", Order=3)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary")]
        public byte[] arg3;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://webservice.viettel.com/", Order=4)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string arg4;
        
        public uploadFile() {
        }
        
        public uploadFile(string arg0, string arg1, string arg2, byte[] arg3, string arg4) {
            this.arg0 = arg0;
            this.arg1 = arg1;
            this.arg2 = arg2;
            this.arg3 = arg3;
            this.arg4 = arg4;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="uploadFileResponse", WrapperNamespace="http://webservice.viettel.com/", IsWrapped=true)]
    public partial class uploadFileResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://webservice.viettel.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool @return;
        
        public uploadFileResponse() {
        }
        
        public uploadFileResponse(bool @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getLastVersion", WrapperNamespace="http://webservice.viettel.com/", IsWrapped=true)]
    public partial class getLastVersion {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://webservice.viettel.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string arg0;
        
        public getLastVersion() {
        }
        
        public getLastVersion(string arg0) {
            this.arg0 = arg0;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getLastVersionResponse", WrapperNamespace="http://webservice.viettel.com/", IsWrapped=true)]
    public partial class getLastVersionResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://webservice.viettel.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string[] @return;
        
        public getLastVersionResponse() {
        }
        
        public getLastVersionResponse(string[] @return) {
            this.@return = @return;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://webservice.viettel.com/")]
    public partial class synObject : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string fileNameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string fileName {
            get {
                return this.fileNameField;
            }
            set {
                this.fileNameField = value;
                this.RaisePropertyChanged("fileName");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getUpdateData", WrapperNamespace="http://webservice.viettel.com/", IsWrapped=true)]
    public partial class getUpdateData {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://webservice.viettel.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string arg0;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://webservice.viettel.com/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string arg1;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://webservice.viettel.com/", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string arg2;
        
        public getUpdateData() {
        }
        
        public getUpdateData(string arg0, string arg1, string arg2) {
            this.arg0 = arg0;
            this.arg1 = arg1;
            this.arg2 = arg2;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getUpdateDataResponse", WrapperNamespace="http://webservice.viettel.com/", IsWrapped=true)]
    public partial class getUpdateDataResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://webservice.viettel.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public SaleMTSync.SaleOnline.synObject[] @return;
        
        public getUpdateDataResponse() {
        }
        
        public getUpdateDataResponse(SaleMTSync.SaleOnline.synObject[] @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface GetExportDataWsChannel : SaleMTSync.SaleOnline.GetExportDataWs, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetExportDataWsClient : System.ServiceModel.ClientBase<SaleMTSync.SaleOnline.GetExportDataWs>, SaleMTSync.SaleOnline.GetExportDataWs {
        
        public GetExportDataWsClient() {
        }
        
        public GetExportDataWsClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GetExportDataWsClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GetExportDataWsClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GetExportDataWsClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SaleMTSync.SaleOnline.deleteFileResponse SaleMTSync.SaleOnline.GetExportDataWs.deleteFile(SaleMTSync.SaleOnline.deleteFile request) {
            return base.Channel.deleteFile(request);
        }
        
        public void deleteFile(string arg0, string arg1, string[] arg2, string arg3) {
            SaleMTSync.SaleOnline.deleteFile inValue = new SaleMTSync.SaleOnline.deleteFile();
            inValue.arg0 = arg0;
            inValue.arg1 = arg1;
            inValue.arg2 = arg2;
            inValue.arg3 = arg3;
            SaleMTSync.SaleOnline.deleteFileResponse retVal = ((SaleMTSync.SaleOnline.GetExportDataWs)(this)).deleteFile(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SaleMTSync.SaleOnline.uploadFileResponse SaleMTSync.SaleOnline.GetExportDataWs.uploadFile(SaleMTSync.SaleOnline.uploadFile request) {
            return base.Channel.uploadFile(request);
        }
        
        public bool uploadFile(string arg0, string arg1, string arg2, byte[] arg3, string arg4) {
            SaleMTSync.SaleOnline.uploadFile inValue = new SaleMTSync.SaleOnline.uploadFile();
            inValue.arg0 = arg0;
            inValue.arg1 = arg1;
            inValue.arg2 = arg2;
            inValue.arg3 = arg3;
            inValue.arg4 = arg4;
            SaleMTSync.SaleOnline.uploadFileResponse retVal = ((SaleMTSync.SaleOnline.GetExportDataWs)(this)).uploadFile(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SaleMTSync.SaleOnline.getLastVersionResponse SaleMTSync.SaleOnline.GetExportDataWs.getLastVersion(SaleMTSync.SaleOnline.getLastVersion request) {
            return base.Channel.getLastVersion(request);
        }
        
        public string[] getLastVersion(string arg0) {
            SaleMTSync.SaleOnline.getLastVersion inValue = new SaleMTSync.SaleOnline.getLastVersion();
            inValue.arg0 = arg0;
            SaleMTSync.SaleOnline.getLastVersionResponse retVal = ((SaleMTSync.SaleOnline.GetExportDataWs)(this)).getLastVersion(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SaleMTSync.SaleOnline.getUpdateDataResponse SaleMTSync.SaleOnline.GetExportDataWs.getUpdateData(SaleMTSync.SaleOnline.getUpdateData request) {
            return base.Channel.getUpdateData(request);
        }
        
        public SaleMTSync.SaleOnline.synObject[] getUpdateData(string arg0, string arg1, string arg2) {
            SaleMTSync.SaleOnline.getUpdateData inValue = new SaleMTSync.SaleOnline.getUpdateData();
            inValue.arg0 = arg0;
            inValue.arg1 = arg1;
            inValue.arg2 = arg2;
            SaleMTSync.SaleOnline.getUpdateDataResponse retVal = ((SaleMTSync.SaleOnline.GetExportDataWs)(this)).getUpdateData(inValue);
            return retVal.@return;
        }
    }
}
