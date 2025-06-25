using IntegrationAgentComLibrary.InvoiceSchema;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace IntegrationAgentComLibrary.AttachedDocumentSchema
{
    [XmlRoot(ElementName = "CanonicalizationMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public class CanonicalizationMethod
    {
        [XmlAttribute(AttributeName = "Algorithm")]
        public string Algorithm { get; set; }
    }

    [XmlRoot(ElementName = "SignatureMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public class SignatureMethod
    {
        [XmlAttribute(AttributeName = "Algorithm")]
        public string Algorithm { get; set; }
    }

    [XmlRoot(ElementName = "Transform", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public class Transform
    {
        [XmlAttribute(AttributeName = "Algorithm")]
        public string Algorithm { get; set; }
    }

    [XmlRoot(ElementName = "Transforms", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public class Transforms
    {
        [XmlElement(ElementName = "Transform", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public Transform Transform { get; set; }
    }

    [XmlRoot(ElementName = "DigestMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public class DigestMethod
    {
        [XmlAttribute(AttributeName = "Algorithm")]
        public string Algorithm { get; set; }
    }

    [XmlRoot(ElementName = "Reference", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public class Reference
    {
        [XmlElement(ElementName = "Transforms", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public Transforms Transforms { get; set; }
        [XmlElement(ElementName = "DigestMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public DigestMethod DigestMethod { get; set; }
        [XmlElement(ElementName = "DigestValue", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public string DigestValue { get; set; }
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "URI")]
        public string URI { get; set; }
        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "SignedInfo", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public class SignedInfo
    {
        [XmlElement(ElementName = "CanonicalizationMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public CanonicalizationMethod CanonicalizationMethod { get; set; }
        [XmlElement(ElementName = "SignatureMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public SignatureMethod SignatureMethod { get; set; }
        [XmlElement(ElementName = "Reference", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public List<Reference> Reference { get; set; }
    }

    [XmlRoot(ElementName = "SignatureValue", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public class SignatureValue
    {
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "X509Data", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public class X509Data
    {
        [XmlElement(ElementName = "X509Certificate", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public string X509Certificate { get; set; }
    }

    [XmlRoot(ElementName = "KeyInfo", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public class KeyInfo
    {
        [XmlElement(ElementName = "X509Data", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public X509Data X509Data { get; set; }
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "CertDigest", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public class CertDigest
    {
        [XmlElement(ElementName = "DigestMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public DigestMethod DigestMethod { get; set; }
        [XmlElement(ElementName = "DigestValue", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public string DigestValue { get; set; }
    }

    [XmlRoot(ElementName = "IssuerSerial", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public class IssuerSerial
    {
        [XmlElement(ElementName = "X509IssuerName", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public string X509IssuerName { get; set; }
        [XmlElement(ElementName = "X509SerialNumber", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public string X509SerialNumber { get; set; }
    }

    [XmlRoot(ElementName = "Cert", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public class Cert
    {
        [XmlElement(ElementName = "CertDigest", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
        public CertDigest CertDigest { get; set; }
        [XmlElement(ElementName = "IssuerSerial", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
        public IssuerSerial IssuerSerial { get; set; }
    }

    [XmlRoot(ElementName = "SigningCertificate", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public class SigningCertificate
    {
        [XmlElement(ElementName = "Cert", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
        public Cert Cert { get; set; }
    }

    [XmlRoot(ElementName = "SigPolicyId", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public class SigPolicyId
    {
        [XmlElement(ElementName = "Identifier", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
        public string Identifier { get; set; }
        [XmlElement(ElementName = "Description", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
        public string Description { get; set; }
    }

    [XmlRoot(ElementName = "SigPolicyHash", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public class SigPolicyHash
    {
        [XmlElement(ElementName = "DigestMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public DigestMethod DigestMethod { get; set; }
        [XmlElement(ElementName = "DigestValue", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public string DigestValue { get; set; }
    }

    [XmlRoot(ElementName = "SignaturePolicyId", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public class SignaturePolicyId
    {
        [XmlElement(ElementName = "SigPolicyId", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
        public SigPolicyId SigPolicyId { get; set; }
        [XmlElement(ElementName = "SigPolicyHash", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
        public SigPolicyHash SigPolicyHash { get; set; }
    }

    [XmlRoot(ElementName = "SignaturePolicyIdentifier", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public class SignaturePolicyIdentifier
    {
        [XmlElement(ElementName = "SignaturePolicyId", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
        public SignaturePolicyId SignaturePolicyId { get; set; }
    }

    [XmlRoot(ElementName = "ClaimedRoles", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public class ClaimedRoles
    {
        [XmlElement(ElementName = "ClaimedRole", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
        public string ClaimedRole { get; set; }
    }

    [XmlRoot(ElementName = "SignerRole", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public class SignerRole
    {
        [XmlElement(ElementName = "ClaimedRoles", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
        public ClaimedRoles ClaimedRoles { get; set; }
    }

    [XmlRoot(ElementName = "SignedSignatureProperties", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public class SignedSignatureProperties
    {
        [XmlElement(ElementName = "SigningTime", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
        public string SigningTime { get; set; }
        [XmlElement(ElementName = "SigningCertificate", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
        public SigningCertificate SigningCertificate { get; set; }
        [XmlElement(ElementName = "SignaturePolicyIdentifier", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
        public SignaturePolicyIdentifier SignaturePolicyIdentifier { get; set; }
        [XmlElement(ElementName = "SignerRole", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
        public SignerRole SignerRole { get; set; }
    }

    [XmlRoot(ElementName = "DataObjectFormat", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public class DataObjectFormat
    {
        [XmlElement(ElementName = "MimeType", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
        public string MimeType { get; set; }
        [XmlElement(ElementName = "Encoding", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
        public string Encoding { get; set; }
        [XmlAttribute(AttributeName = "ObjectReference")]
        public string ObjectReference { get; set; }
    }

    [XmlRoot(ElementName = "SignedDataObjectProperties", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public class SignedDataObjectProperties
    {
        [XmlElement(ElementName = "DataObjectFormat", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
        public DataObjectFormat DataObjectFormat { get; set; }
    }

    [XmlRoot(ElementName = "SignedProperties", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public class SignedProperties
    {
        [XmlElement(ElementName = "SignedSignatureProperties", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
        public SignedSignatureProperties SignedSignatureProperties { get; set; }
        [XmlElement(ElementName = "SignedDataObjectProperties", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
        public SignedDataObjectProperties SignedDataObjectProperties { get; set; }
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "QualifyingProperties", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public class QualifyingProperties
    {
        [XmlElement(ElementName = "SignedProperties", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
        public SignedProperties SignedProperties { get; set; }
        [XmlAttribute(AttributeName = "xades", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xades { get; set; }
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "Target")]
        public string Target { get; set; }
    }

    [XmlRoot(ElementName = "Object", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public class Object
    {
        [XmlElement(ElementName = "QualifyingProperties", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
        public QualifyingProperties QualifyingProperties { get; set; }
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public class Signature
    {
        [XmlElement(ElementName = "SignedInfo", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public SignedInfo SignedInfo { get; set; }
        [XmlElement(ElementName = "SignatureValue", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public SignatureValue SignatureValue { get; set; }
        [XmlElement(ElementName = "KeyInfo", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public KeyInfo KeyInfo { get; set; }
        [XmlElement(ElementName = "Object", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public Object Object { get; set; }
        [XmlAttribute(AttributeName = "ds", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ds { get; set; }
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "ExtensionContent", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")]
    public class ExtensionContent
    {
        [XmlElement(ElementName = "Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public Signature Signature { get; set; }
    }

    [XmlRoot(ElementName = "UBLExtension", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")]
    public class UBLExtension
    {
        [XmlElement(ElementName = "ExtensionContent", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")]
        public ExtensionContent ExtensionContent { get; set; }
    }

    [XmlRoot(ElementName = "UBLExtensions", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")]
    public class UBLExtensions
    {
        [XmlElement(ElementName = "UBLExtension", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")]
        public UBLExtension UBLExtension { get; set; }
    }

    [XmlRoot(ElementName = "CompanyID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public class CompanyID
    {
        [XmlAttribute(AttributeName = "schemeAgencyID")]
        public string SchemeAgencyID { get; set; }
        [XmlAttribute(AttributeName = "schemeID")]
        public string SchemeID { get; set; }
        [XmlAttribute(AttributeName = "schemeName")]
        public string SchemeName { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "TaxScheme", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class TaxScheme
    {
        [XmlElement(ElementName = "ID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string ID { get; set; }
        [XmlElement(ElementName = "Name", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "PartyTaxScheme", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class PartyTaxScheme
    {
        [XmlElement(ElementName = "RegistrationName", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string RegistrationName { get; set; }
        [XmlElement(ElementName = "CompanyID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public CompanyID CompanyID { get; set; }
        [XmlElement(ElementName = "TaxLevelCode", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string TaxLevelCode { get; set; }
        [XmlElement(ElementName = "TaxScheme", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public TaxScheme TaxScheme { get; set; }
    }

    [XmlRoot(ElementName = "SenderParty", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class SenderParty
    {
        [XmlElement(ElementName = "PartyTaxScheme", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public PartyTaxScheme PartyTaxScheme { get; set; }
    }

    [XmlRoot(ElementName = "ReceiverParty", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class ReceiverParty
    {
        [XmlElement(ElementName = "PartyTaxScheme", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public PartyTaxScheme PartyTaxScheme { get; set; }
    }

    [XmlRoot(ElementName = "ExternalReference", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class ExternalReference
    {
        [XmlElement(ElementName = "MimeCode", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string MimeCode { get; set; }
        [XmlElement(ElementName = "EncodingCode", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string EncodingCode { get; set; }
        [XmlElement(ElementName = "Description", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string Description { get; set; }
        [XmlIgnore]
        public Invoice Invoice { get; set; }
    }

    [XmlRoot(ElementName = "Attachment", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class Attachment
    {
        [XmlElement(ElementName = "ExternalReference", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public ExternalReference ExternalReference { get; set; }
    }

    [XmlRoot(ElementName = "UUID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public class UUID
    {
        [XmlAttribute(AttributeName = "schemeName")]
        public string SchemeName { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "ResultOfVerification", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class ResultOfVerification
    {
        [XmlElement(ElementName = "ValidatorID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string ValidatorID { get; set; }
        [XmlElement(ElementName = "ValidationResultCode", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string ValidationResultCode { get; set; }
        [XmlElement(ElementName = "ValidationDate", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string ValidationDate { get; set; }
        [XmlElement(ElementName = "ValidationTime", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string ValidationTime { get; set; }
    }

    [XmlRoot(ElementName = "DocumentReference", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class DocumentReference
    {
        [XmlElement(ElementName = "ID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string ID { get; set; }
        [XmlElement(ElementName = "UUID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public UUID UUID { get; set; }
        [XmlElement(ElementName = "IssueDate", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string IssueDate { get; set; }
        [XmlElement(ElementName = "DocumentType", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string DocumentType { get; set; }
        [XmlElement(ElementName = "Attachment", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public Attachment Attachment { get; set; }
        [XmlElement(ElementName = "ResultOfVerification", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public ResultOfVerification ResultOfVerification { get; set; }
    }

    [XmlRoot(ElementName = "ParentDocumentLineReference", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class ParentDocumentLineReference
    {
        [XmlElement(ElementName = "LineID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string LineID { get; set; }
        [XmlElement(ElementName = "DocumentReference", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public DocumentReference DocumentReference { get; set; }
    }

    [ComVisible(true)]
    [ProgId("AttachedDocument.Class")]
    [Guid("b37e8415-608a-48cb-90b0-f94025663956")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [XmlRoot(ElementName = "AttachedDocument", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:AttachedDocument-2")]
    public class AttachedDocument
    {
        [XmlElement(ElementName = "UBLExtensions", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")]
        public UBLExtensions UBLExtensions { get; set; }
        [XmlElement(ElementName = "UBLVersionID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string UBLVersionID { get; set; }
        [XmlElement(ElementName = "CustomizationID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string CustomizationID { get; set; }
        [XmlElement(ElementName = "ProfileID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string ProfileID { get; set; }
        [XmlElement(ElementName = "ProfileExecutionID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string ProfileExecutionID { get; set; }
        [XmlElement(ElementName = "ID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string ID { get; set; }
        [XmlElement(ElementName = "IssueDate", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string IssueDate { get; set; }
        [XmlElement(ElementName = "IssueTime", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string IssueTime { get; set; }
        [XmlElement(ElementName = "DocumentType", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string DocumentType { get; set; }
        [XmlElement(ElementName = "ParentDocumentID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string ParentDocumentID { get; set; }
        [XmlElement(ElementName = "SenderParty", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public SenderParty SenderParty { get; set; }
        [XmlElement(ElementName = "ReceiverParty", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public ReceiverParty ReceiverParty { get; set; }
        [XmlElement(ElementName = "Attachment", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public Attachment Attachment { get; set; }
        [XmlElement(ElementName = "ParentDocumentLineReference", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public ParentDocumentLineReference ParentDocumentLineReference { get; set; }
        [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
        [XmlAttribute(AttributeName = "xades", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xades { get; set; }
        [XmlAttribute(AttributeName = "ds", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ds { get; set; }
        [XmlAttribute(AttributeName = "cac", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Cac { get; set; }
        [XmlAttribute(AttributeName = "cbc", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Cbc { get; set; }
        [XmlAttribute(AttributeName = "ext", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ext { get; set; }
        [XmlAttribute(AttributeName = "n1", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string N1 { get; set; }
        [XmlAttribute(AttributeName = "qdt", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Qdt { get; set; }
        [XmlAttribute(AttributeName = "sac", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Sac { get; set; }
        [XmlAttribute(AttributeName = "sbc", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Sbc { get; set; }
        [XmlAttribute(AttributeName = "udt", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Udt { get; set; }
        [XmlAttribute(AttributeName = "ccts-cct", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Cctscct { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
    }
}
