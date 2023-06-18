namespace HatDieu.Infrastructure.PayrixGateway.PayrixGatewayModels;

public class PayrixEntityResponseModel
{
    public string Id { get; set; } = string.Empty;
    public DateTime? Modified { get; set; }
    public DateTime? Created { get; set; }

    public string Creator { get; set; } = string.Empty;
    public string Modifier { get; set; } = string.Empty;
    public string IpCreated { get; set; } = string.Empty;
    public string IpModified { get; set; } = string.Empty;
    public string ClientIp { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public int Type { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address1 { get; set; } = string.Empty;
    public string Address2 { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Zip { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Timezone { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Fax { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;
    public string Ein { get; set; } = string.Empty;
    public string TcVersion { get; set; } = string.Empty;
    public DateTime? TcDate { get; set; }
    public string TcIp { get; set; } = string.Empty;
    public DateTime? TcAcceptDate { get; set; }
    public string TcAcceptIp { get; set; } = string.Empty;
    public string Custom { get; set; } = string.Empty;
    public int Inactive { get; set; }
    public int Frozen { get; set; }
    public int TinStatus { get; set; }
    public int Reserved { get; set; }
    public string CheckStage { get; set; } = string.Empty;
    public int Public { get; set; }
    public string CustomerPhone { get; set; } = string.Empty;
    public int Locations { get; set; }
    public string Industry { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public int TotalCreditDisbursements { get; set; }
    public string PayoutSecondaryDescriptor { get; set; } = string.Empty;
    public string EinType { get; set; } = string.Empty;
    public string IrsFilingName { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
}