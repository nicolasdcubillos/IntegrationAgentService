using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace IntegrationAgentService.Models.InvoiceSchema
{
    [XmlRoot(ElementName = "AuthorizationPeriod", Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
    public class AuthorizationPeriod
    {
        [XmlElement(ElementName = "StartDate", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string StartDate { get; set; }
        [XmlElement(ElementName = "EndDate", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string EndDate { get; set; }
    }

    [XmlRoot(ElementName = "AuthorizedInvoices", Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
    public class AuthorizedInvoices
    {
        [XmlElement(ElementName = "Prefix", Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
        public string Prefix { get; set; }
        [XmlElement(ElementName = "From", Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
        public string From { get; set; }
        [XmlElement(ElementName = "To", Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
        public string To { get; set; }
    }

    [XmlRoot(ElementName = "InvoiceControl", Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
    public class InvoiceControl
    {
        [XmlElement(ElementName = "InvoiceAuthorization", Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
        public string InvoiceAuthorization { get; set; }
        [XmlElement(ElementName = "AuthorizationPeriod", Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
        public AuthorizationPeriod AuthorizationPeriod { get; set; }
        [XmlElement(ElementName = "AuthorizedInvoices", Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
        public AuthorizedInvoices AuthorizedInvoices { get; set; }
    }

    [XmlRoot("IdentificationCode", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public class IdentificationCode
    {
        [XmlAttribute(AttributeName = "listAgencyID")]
        public string ListAgencyID { get; set; }
        [XmlAttribute(AttributeName = "listAgencyName")]
        public string ListAgencyName { get; set; }
        [XmlAttribute(AttributeName = "listSchemeURI")]
        public string ListSchemeURI { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "InvoiceSource", Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
    public class InvoiceSource
    {
        [XmlElement(ElementName = "IdentificationCode")]
        public IdentificationCode IdentificationCode { get; set; }
    }

    [XmlRoot(ElementName = "ProviderID", Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
    public class ProviderID
    {
        [XmlAttribute(AttributeName = "schemeAgencyID")]
        public string SchemeAgencyID { get; set; }
        [XmlAttribute(AttributeName = "schemeAgencyName")]
        public string SchemeAgencyName { get; set; }
        [XmlAttribute(AttributeName = "schemeID")]
        public string SchemeID { get; set; }
        [XmlAttribute(AttributeName = "schemeName")]
        public string SchemeName { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "SoftwareID", Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
    public class SoftwareID
    {
        [XmlAttribute(AttributeName = "schemeAgencyID")]
        public string SchemeAgencyID { get; set; }
        [XmlAttribute(AttributeName = "schemeAgencyName")]
        public string SchemeAgencyName { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "SoftwareProvider", Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
    public class SoftwareProvider
    {
        [XmlElement(ElementName = "ProviderID", Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
        public ProviderID ProviderID { get; set; }
        [XmlElement(ElementName = "SoftwareID", Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
        public SoftwareID SoftwareID { get; set; }
    }

    [XmlRoot(ElementName = "SoftwareSecurityCode", Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
    public class SoftwareSecurityCode
    {
        [XmlAttribute(AttributeName = "schemeAgencyID")]
        public string SchemeAgencyID { get; set; }
        [XmlAttribute(AttributeName = "schemeAgencyName")]
        public string SchemeAgencyName { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "AuthorizationProviderID", Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
    public class AuthorizationProviderID
    {
        [XmlAttribute(AttributeName = "schemeAgencyID")]
        public string SchemeAgencyID { get; set; }
        [XmlAttribute(AttributeName = "schemeAgencyName")]
        public string SchemeAgencyName { get; set; }
        [XmlAttribute(AttributeName = "schemeID")]
        public string SchemeID { get; set; }
        [XmlAttribute(AttributeName = "schemeName")]
        public string SchemeName { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "AuthorizationProvider", Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
    public class AuthorizationProvider
    {
        [XmlElement(ElementName = "AuthorizationProviderID", Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
        public AuthorizationProviderID AuthorizationProviderID { get; set; }
    }

    [XmlRoot(ElementName = "DianExtensions", Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
    public class DianExtensions
    {
        [XmlElement(ElementName = "InvoiceControl", Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
        public InvoiceControl InvoiceControl { get; set; }
        [XmlElement(ElementName = "InvoiceSource", Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
        public InvoiceSource InvoiceSource { get; set; }
        [XmlElement(ElementName = "SoftwareProvider", Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
        public SoftwareProvider SoftwareProvider { get; set; }
        [XmlElement(ElementName = "SoftwareSecurityCode", Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
        public SoftwareSecurityCode SoftwareSecurityCode { get; set; }
        [XmlElement(ElementName = "AuthorizationProvider", Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
        public AuthorizationProvider AuthorizationProvider { get; set; }
        [XmlElement(ElementName = "QRCode", Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
        public string QRCode { get; set; }
    }

    [XmlRoot(ElementName = "ExtensionContent", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")]
    public class ExtensionContent
    {
        [XmlElement(ElementName = "DianExtensions", Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
        public DianExtensions DianExtensions { get; set; }
        [XmlElement(ElementName = "Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public Signature Signature { get; set; }
    }

    [XmlRoot(ElementName = "UBLExtension", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")]
    public class UBLExtension
    {
        [XmlElement(ElementName = "ExtensionContent", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")]
        public ExtensionContent ExtensionContent { get; set; }
    }

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

    [XmlRoot(ElementName = "UBLExtensions", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")]
    public class UBLExtensions
    {
        [XmlElement(ElementName = "UBLExtension", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")]
        public List<UBLExtension> UBLExtension { get; set; }
    }

    [XmlRoot(ElementName = "UUID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public class UUID
    {
        [XmlAttribute(AttributeName = "schemeID")]
        public string SchemeID { get; set; }
        [XmlAttribute(AttributeName = "schemeName")]
        public string SchemeName { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "ReceiptDocumentReference", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class ReceiptDocumentReference
    {
        [XmlElement(ElementName = "ID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID { get; set; }
    }

    [XmlRoot(ElementName = "AdditionalAccountID")]
    public class AdditionalAccountID
    {
        [XmlAttribute(AttributeName = "schemeAgencyID")]
        public string SchemeAgencyID { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "PartyName", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class PartyName
    {
        [XmlElement(ElementName = "Name", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "AddressLine", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class AddressLine
    {
        [XmlElement(ElementName = "Line", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string Line { get; set; }
    }

    [XmlRoot(ElementName = "Name", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public class Name
    {
        [XmlAttribute(AttributeName = "languageID")]
        public string LanguageID { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Country", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class Country
    {
        [XmlElement(ElementName = "IdentificationCode", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public IdentificationCode IdentificationCode { get; set; }

        [XmlElement(ElementName = "Name", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public Name Name { get; set; }
    }

    [XmlRoot(ElementName = "Address", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class Address
    {
        [XmlElement(ElementName = "ID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID { get; set; }
        [XmlElement(ElementName = "CityName", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string CityName { get; set; }
        [XmlElement(ElementName = "PostalZone", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string PostalZone { get; set; }
        [XmlElement(ElementName = "CountrySubentity", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string CountrySubentity { get; set; }
        [XmlElement(ElementName = "CountrySubentityCode", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string CountrySubentityCode { get; set; }
        [XmlElement(ElementName = "AddressLine", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public AddressLine AddressLine { get; set; }
        [XmlElement(ElementName = "Country")]
        public Country Country { get; set; }
    }

    [XmlRoot(ElementName = "PhysicalLocation", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class PhysicalLocation
    {
        [XmlElement(ElementName = "Address", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public Address Address { get; set; }
    }

    [XmlRoot(ElementName = "CompanyID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public class CompanyID
    {
        [XmlAttribute(AttributeName = "schemeID")]
        public string SchemeID { get; set; }
        [XmlAttribute(AttributeName = "schemeName")]
        public string SchemeName { get; set; }
        [XmlAttribute(AttributeName = "schemeAgencyID")]
        public string SchemeAgencyID { get; set; }
        [XmlAttribute(AttributeName = "schemeAgencyName")]
        public string SchemeAgencyName { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "RegistrationAddress", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class RegistrationAddress
    {
        [XmlElement(ElementName = "ID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID { get; set; }
        [XmlElement(ElementName = "CityName", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string CityName { get; set; }
        [XmlElement(ElementName = "PostalZone", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string PostalZone { get; set; }
        [XmlElement(ElementName = "CountrySubentity", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string CountrySubentity { get; set; }
        [XmlElement(ElementName = "CountrySubentityCode", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string CountrySubentityCode { get; set; }
        [XmlElement(ElementName = "AddressLine", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public AddressLine AddressLine { get; set; }
        [XmlElement(ElementName = "Country", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public Country Country { get; set; }
    }

    [XmlRoot(ElementName = "TaxScheme", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class TaxScheme
    {
        [XmlElement(ElementName = "ID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID { get; set; }
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
        [XmlElement(ElementName = "RegistrationAddress", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public RegistrationAddress RegistrationAddress { get; set; }
        [XmlElement(ElementName = "TaxScheme", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public TaxScheme TaxScheme { get; set; }
    }

    [XmlRoot(ElementName = "CorporateRegistrationScheme", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class CorporateRegistrationScheme
    {
        [XmlElement(ElementName = "ID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID { get; set; }
    }

    [XmlRoot(ElementName = "PartyLegalEntity", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class PartyLegalEntity
    {
        [XmlElement(ElementName = "RegistrationName", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string RegistrationName { get; set; }
        [XmlElement(ElementName = "CompanyID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public CompanyID CompanyID { get; set; }
        [XmlElement(ElementName = "CorporateRegistrationScheme", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public CorporateRegistrationScheme CorporateRegistrationScheme { get; set; }
    }

    [XmlRoot(ElementName = "Contact", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class Contact
    {
        [XmlElement(ElementName = "Name", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Telephone", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string Telephone { get; set; }
        [XmlElement(ElementName = "ElectronicMail", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string ElectronicMail { get; set; }
    }

    [XmlRoot(ElementName = "Party", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class Party
    {
        [XmlElement(ElementName = "IndustryClassificationCode", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string IndustryClassificationCode { get; set; }
        [XmlElement(ElementName = "PartyName", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public PartyName PartyName { get; set; }
        [XmlElement(ElementName = "PhysicalLocation", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public PhysicalLocation PhysicalLocation { get; set; }
        [XmlElement(ElementName = "PartyTaxScheme", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public PartyTaxScheme PartyTaxScheme { get; set; }
        [XmlElement(ElementName = "PartyLegalEntity", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public PartyLegalEntity PartyLegalEntity { get; set; }
        [XmlElement(ElementName = "Contact", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public Contact Contact { get; set; }
    }

    [XmlRoot(ElementName = "AccountingSupplierParty", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class AccountingSupplierParty
    {
        [XmlElement(ElementName = "AdditionalAccountID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public AdditionalAccountID AdditionalAccountID { get; set; }
        [XmlElement(ElementName = "Party", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public Party Party { get; set; }
    }

    [XmlRoot(ElementName = "AccountingCustomerParty", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class AccountingCustomerParty
    {
        [XmlElement(ElementName = "AdditionalAccountID")]
        public string AdditionalAccountID { get; set; }
        [XmlElement(ElementName = "Party", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public Party Party { get; set; }
    }

    [XmlRoot(ElementName = "PaymentMeans", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class PaymentMeans
    {
        [XmlElement(ElementName = "ID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID { get; set; }
        [XmlElement(ElementName = "PaymentMeansCode", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string PaymentMeansCode { get; set; }
        [XmlElement(ElementName = "PaymentDueDate", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string PaymentDueDate { get; set; }
    }

    [XmlRoot(ElementName = "TaxAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public class TaxAmount
    {
        [XmlAttribute(AttributeName = "currencyID")]
        public string CurrencyID { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "RoundingAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public class RoundingAmount
    {
        [XmlAttribute(AttributeName = "currencyID")]
        public string CurrencyID { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "TaxableAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public class TaxableAmount
    {
        [XmlAttribute(AttributeName = "currencyID")]
        public string CurrencyID { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "TaxCategory", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class TaxCategory
    {
        [XmlElement(ElementName = "Percent", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string Percent { get; set; }
        [XmlElement(ElementName = "TaxScheme", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public TaxScheme TaxScheme { get; set; }
    }

    [XmlRoot(ElementName = "TaxSubtotal", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class TaxSubtotal
    {
        [XmlElement(ElementName = "TaxableAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TaxableAmount TaxableAmount { get; set; }
        [XmlElement(ElementName = "TaxAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TaxAmount TaxAmount { get; set; }
        [XmlElement(ElementName = "TaxCategory", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public TaxCategory TaxCategory { get; set; }
    }

    [XmlRoot(ElementName = "TaxTotal", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class TaxTotal
    {
        [XmlElement(ElementName = "TaxAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TaxAmount TaxAmount { get; set; }
        [XmlElement(ElementName = "RoundingAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public RoundingAmount RoundingAmount { get; set; }
        [XmlElement(ElementName = "TaxSubtotal", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public TaxSubtotal TaxSubtotal { get; set; }
    }

    [XmlRoot(ElementName = "LineExtensionAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public class LineExtensionAmount
    {
        [XmlAttribute(AttributeName = "currencyID")]
        public string CurrencyID { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "TaxExclusiveAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public class TaxExclusiveAmount
    {
        [XmlAttribute(AttributeName = "currencyID")]
        public string CurrencyID { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "TaxInclusiveAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public class TaxInclusiveAmount
    {
        [XmlAttribute(AttributeName = "currencyID")]
        public string CurrencyID { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "AllowanceTotalAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public class AllowanceTotalAmount
    {
        [XmlAttribute(AttributeName = "currencyID")]
        public string CurrencyID { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "ChargeTotalAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public class ChargeTotalAmount
    {
        [XmlAttribute(AttributeName = "currencyID")]
        public string CurrencyID { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "PayableAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public class PayableAmount
    {
        [XmlAttribute(AttributeName = "currencyID")]
        public string CurrencyID { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "LegalMonetaryTotal", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class LegalMonetaryTotal
    {
        [XmlElement(ElementName = "LineExtensionAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public LineExtensionAmount LineExtensionAmount { get; set; }
        [XmlElement(ElementName = "TaxExclusiveAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TaxExclusiveAmount TaxExclusiveAmount { get; set; }
        [XmlElement(ElementName = "TaxInclusiveAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TaxInclusiveAmount TaxInclusiveAmount { get; set; }
        [XmlElement(ElementName = "AllowanceTotalAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public AllowanceTotalAmount AllowanceTotalAmount { get; set; }
        [XmlElement(ElementName = "ChargeTotalAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ChargeTotalAmount ChargeTotalAmount { get; set; }
        [XmlElement(ElementName = "PayableAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public PayableAmount PayableAmount { get; set; }
    }

    [XmlRoot(ElementName = "InvoicedQuantity", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public class InvoicedQuantity
    {
        [XmlAttribute(AttributeName = "unitCode")]
        public string UnitCode { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "ID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public class ID
    {
        [XmlAttribute(AttributeName = "schemeID")]
        public string SchemeID { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "StandardItemIdentification", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class StandardItemIdentification
    {
        [XmlElement(ElementName = "ID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID { get; set; }
    }

    [XmlRoot(ElementName = "Item", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class Item
    {
        [XmlElement(ElementName = "Description", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string Description { get; set; }
        [XmlElement(ElementName = "StandardItemIdentification", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public StandardItemIdentification StandardItemIdentification { get; set; }
    }

    [XmlRoot(ElementName = "PriceAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public class PriceAmount
    {
        [XmlAttribute(AttributeName = "currencyID")]
        public string CurrencyID { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "BaseQuantity", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public class BaseQuantity
    {
        [XmlAttribute(AttributeName = "unitCode")]
        public string UnitCode { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Price", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class Price
    {
        [XmlElement(ElementName = "PriceAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public PriceAmount PriceAmount { get; set; }
        [XmlElement(ElementName = "BaseQuantity", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public BaseQuantity BaseQuantity { get; set; }
    }

    [XmlRoot(ElementName = "InvoiceLine", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class InvoiceLine
    {
        [XmlElement(ElementName = "ID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID { get; set; }
        [XmlElement(ElementName = "InvoicedQuantity", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public InvoicedQuantity InvoicedQuantity { get; set; }
        [XmlElement(ElementName = "LineExtensionAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public LineExtensionAmount LineExtensionAmount { get; set; }
        [XmlElement(ElementName = "TaxTotal", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public TaxTotal TaxTotal { get; set; }
        [XmlElement(ElementName = "Item", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public Item Item { get; set; }
        [XmlElement(ElementName = "Price", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public Price Price { get; set; }
    }

    [XmlRoot(ElementName = "Invoice", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2")]
    public class Invoice
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
        public ID ID { get; set; }
        [XmlElement(ElementName = "UUID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public UUID UUID { get; set; }
        [XmlElement(ElementName = "IssueDate", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string IssueDate { get; set; }
        [XmlElement(ElementName = "IssueTime", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string IssueTime { get; set; }
        [XmlElement(ElementName = "InvoiceTypeCode", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string InvoiceTypeCode { get; set; }
        [XmlElement(ElementName = "Note", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string Note { get; set; }
        [XmlElement(ElementName = "DocumentCurrencyCode", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string DocumentCurrencyCode { get; set; }
        [XmlElement(ElementName = "LineCountNumeric", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string LineCountNumeric { get; set; }
        [XmlElement(ElementName = "ReceiptDocumentReference", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public ReceiptDocumentReference ReceiptDocumentReference { get; set; }
        [XmlElement(ElementName = "AccountingSupplierParty", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public AccountingSupplierParty AccountingSupplierParty { get; set; }
        [XmlElement(ElementName = "AccountingCustomerParty", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public AccountingCustomerParty AccountingCustomerParty { get; set; }
        [XmlElement(ElementName = "PaymentMeans", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public PaymentMeans PaymentMeans { get; set; }
        [XmlElement(ElementName = "TaxTotal", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public TaxTotal TaxTotal { get; set; }
        [XmlElement(ElementName = "LegalMonetaryTotal", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public LegalMonetaryTotal LegalMonetaryTotal { get; set; }
        [XmlElement(ElementName = "InvoiceLine", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public List<InvoiceLine> InvoiceLine { get; set; }
        [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
        [XmlAttribute(AttributeName = "sts", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Sts { get; set; }
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
        [XmlAttribute(AttributeName = "n0", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string N0 { get; set; }
        [XmlAttribute(AttributeName = "qdt", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Qdt { get; set; }
        [XmlAttribute(AttributeName = "sac", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Sac { get; set; }
        [XmlAttribute(AttributeName = "sbc", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Sbc { get; set; }
        [XmlAttribute(AttributeName = "udt", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Udt { get; set; }
        [XmlAttribute(AttributeName = "ccts", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ccts { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
    }
}
