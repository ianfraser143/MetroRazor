using BlazorApp.Web.Data;
using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;

namespace BlazorApp.Web.Data;

public sealed class MongoUserStore : IUserPasswordStore<ApplicationUser>, IUserEmailStore<ApplicationUser>, IUserPhoneNumberStore<ApplicationUser>, IUserSecurityStampStore<ApplicationUser>, IUserLockoutStore<ApplicationUser>, IUserTwoFactorStore<ApplicationUser>, IUserLoginStore<ApplicationUser>, IUserAuthenticationTokenStore<ApplicationUser>, IUserAuthenticatorKeyStore<ApplicationUser>, IUserTwoFactorRecoveryCodeStore<ApplicationUser>, IUserPasskeyStore<ApplicationUser>
{
    private readonly ApplicationDbContext _context;

    public MongoUserStore(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.Id ??= Guid.NewGuid().ToString();
        user.SecurityStamp ??= Guid.NewGuid().ToString();
        user.ConcurrencyStamp ??= Guid.NewGuid().ToString();
        return CreateUserAsync(user, cancellationToken);
    }

    private async Task<IdentityResult> CreateUserAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        await _context.Users.InsertOneAsync(user, cancellationToken: cancellationToken);
        return IdentityResult.Success;
    }

    public async Task<IdentityResult> UpdateAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ConcurrencyStamp = Guid.NewGuid().ToString();
        var result = await _context.Users.ReplaceOneAsync(x => x.Id == user.Id, user, cancellationToken: cancellationToken);
        return result.MatchedCount == 1 ? IdentityResult.Success : IdentityResult.Failed(new IdentityError { Description = "The user no longer exists." });
    }

    public async Task<IdentityResult> DeleteAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        var result = await _context.Users.DeleteOneAsync(x => x.Id == user.Id, cancellationToken);
        await _context.UserLogins.DeleteManyAsync(x => x.UserId == user.Id, cancellationToken);
        await _context.UserPasskeys.DeleteManyAsync(x => x.UserId == user.Id, cancellationToken);
        return result.DeletedCount == 1 ? IdentityResult.Success : IdentityResult.Failed(new IdentityError { Description = "The user no longer exists." });
    }

    public Task<string> GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken = default) => Task.FromResult(user.Id);
    public Task<string?> GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken = default) => Task.FromResult(user.UserName);
    public Task SetUserNameAsync(ApplicationUser user, string? userName, CancellationToken cancellationToken = default)
    {
        user.UserName = userName;
        return Task.CompletedTask;
    }
    public Task<string?> GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken = default) => Task.FromResult(user.NormalizedUserName);
    public Task SetNormalizedUserNameAsync(ApplicationUser user, string? normalizedName, CancellationToken cancellationToken = default)
    {
        user.NormalizedUserName = normalizedName;
        return Task.CompletedTask;
    }
    public Task<ApplicationUser?> FindByIdAsync(string userId, CancellationToken cancellationToken = default) =>
        _context.Users.Find(x => x.Id == userId).FirstOrDefaultAsync(cancellationToken);
    public Task<ApplicationUser?> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken = default) =>
        _context.Users.Find(x => x.NormalizedUserName == normalizedUserName).FirstOrDefaultAsync(cancellationToken);

    public Task SetPasswordHashAsync(ApplicationUser user, string? passwordHash, CancellationToken cancellationToken = default)
    {
        user.PasswordHash = passwordHash;
        return Task.CompletedTask;
    }
    public Task<string?> GetPasswordHashAsync(ApplicationUser user, CancellationToken cancellationToken = default) => Task.FromResult(user.PasswordHash);
    public Task<bool> HasPasswordAsync(ApplicationUser user, CancellationToken cancellationToken = default) => Task.FromResult(user.PasswordHash is not null);

    public Task SetEmailAsync(ApplicationUser user, string? email, CancellationToken cancellationToken = default)
    {
        user.Email = email;
        return Task.CompletedTask;
    }
    public Task<string?> GetEmailAsync(ApplicationUser user, CancellationToken cancellationToken = default) => Task.FromResult(user.Email);
    public Task<bool> GetEmailConfirmedAsync(ApplicationUser user, CancellationToken cancellationToken = default) => Task.FromResult(user.EmailConfirmed);
    public Task SetEmailConfirmedAsync(ApplicationUser user, bool confirmed, CancellationToken cancellationToken = default)
    {
        user.EmailConfirmed = confirmed;
        return Task.CompletedTask;
    }
    public Task<ApplicationUser?> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken = default) =>
        _context.Users.Find(x => x.NormalizedEmail == normalizedEmail).FirstOrDefaultAsync(cancellationToken);
    public Task<string?> GetNormalizedEmailAsync(ApplicationUser user, CancellationToken cancellationToken = default) => Task.FromResult(user.NormalizedEmail);
    public Task SetNormalizedEmailAsync(ApplicationUser user, string? normalizedEmail, CancellationToken cancellationToken = default)
    {
        user.NormalizedEmail = normalizedEmail;
        return Task.CompletedTask;
    }

    public Task SetPhoneNumberAsync(ApplicationUser user, string? phoneNumber, CancellationToken cancellationToken = default)
    {
        user.PhoneNumber = phoneNumber;
        return Task.CompletedTask;
    }
    public Task<string?> GetPhoneNumberAsync(ApplicationUser user, CancellationToken cancellationToken = default) => Task.FromResult(user.PhoneNumber);
    public Task<bool> GetPhoneNumberConfirmedAsync(ApplicationUser user, CancellationToken cancellationToken = default) => Task.FromResult(user.PhoneNumberConfirmed);
    public Task SetPhoneNumberConfirmedAsync(ApplicationUser user, bool confirmed, CancellationToken cancellationToken = default)
    {
        user.PhoneNumberConfirmed = confirmed;
        return Task.CompletedTask;
    }

    public Task SetSecurityStampAsync(ApplicationUser user, string stamp, CancellationToken cancellationToken = default)
    {
        user.SecurityStamp = stamp;
        return Task.CompletedTask;
    }
    public Task<string?> GetSecurityStampAsync(ApplicationUser user, CancellationToken cancellationToken = default) => Task.FromResult(user.SecurityStamp);

    public Task<DateTimeOffset?> GetLockoutEndDateAsync(ApplicationUser user, CancellationToken cancellationToken = default) => Task.FromResult(user.LockoutEnd);
    public Task SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset? lockoutEnd, CancellationToken cancellationToken = default)
    {
        user.LockoutEnd = lockoutEnd;
        return Task.CompletedTask;
    }
    public Task<int> IncrementAccessFailedCountAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        user.AccessFailedCount++;
        return Task.FromResult(user.AccessFailedCount);
    }
    public Task ResetAccessFailedCountAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        user.AccessFailedCount = 0;
        return Task.CompletedTask;
    }
    public Task<int> GetAccessFailedCountAsync(ApplicationUser user, CancellationToken cancellationToken = default) => Task.FromResult(user.AccessFailedCount);
    public Task<bool> GetLockoutEnabledAsync(ApplicationUser user, CancellationToken cancellationToken = default) => Task.FromResult(user.LockoutEnabled);
    public Task SetLockoutEnabledAsync(ApplicationUser user, bool enabled, CancellationToken cancellationToken = default)
    {
        user.LockoutEnabled = enabled;
        return Task.CompletedTask;
    }

    public Task SetTwoFactorEnabledAsync(ApplicationUser user, bool enabled, CancellationToken cancellationToken = default)
    {
        user.TwoFactorEnabled = enabled;
        return Task.CompletedTask;
    }
    public Task<bool> GetTwoFactorEnabledAsync(ApplicationUser user, CancellationToken cancellationToken = default) => Task.FromResult(user.TwoFactorEnabled);

    public async Task AddLoginAsync(ApplicationUser user, UserLoginInfo login, CancellationToken cancellationToken = default)
    {
        await _context.UserLogins.InsertOneAsync(new ApplicationUserLogin
        {
            UserId = user.Id,
            LoginProvider = login.LoginProvider,
            ProviderKey = login.ProviderKey,
            ProviderDisplayName = login.ProviderDisplayName
        }, cancellationToken: cancellationToken);
    }
    public async Task RemoveLoginAsync(ApplicationUser user, string loginProvider, string providerKey, CancellationToken cancellationToken = default) =>
        await _context.UserLogins.DeleteOneAsync(x => x.UserId == user.Id && x.LoginProvider == loginProvider && x.ProviderKey == providerKey, cancellationToken);
    public async Task<IList<UserLoginInfo>> GetLoginsAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        var logins = await _context.UserLogins.Find(x => x.UserId == user.Id).ToListAsync(cancellationToken);
        return logins.Select(x => new UserLoginInfo(x.LoginProvider, x.ProviderKey, x.ProviderDisplayName)).ToList();
    }
    public async Task<ApplicationUser?> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken = default)
    {
        var login = await _context.UserLogins.Find(x => x.LoginProvider == loginProvider && x.ProviderKey == providerKey).FirstOrDefaultAsync(cancellationToken);
        return login is null ? null : await FindByIdAsync(login.UserId, cancellationToken);
    }

    public async Task SetTokenAsync(ApplicationUser user, string loginProvider, string name, string? value, CancellationToken cancellationToken = default)
    {
        var filter = Builders<ApplicationUserToken>.Filter.Eq(x => x.UserId, user.Id) &
                     Builders<ApplicationUserToken>.Filter.Eq(x => x.LoginProvider, loginProvider) &
                     Builders<ApplicationUserToken>.Filter.Eq(x => x.Name, name);
        var update = Builders<ApplicationUserToken>.Update.Set(x => x.Value, value);
        await _context.UserTokens.UpdateOneAsync(filter, update, new UpdateOptions { IsUpsert = true }, cancellationToken);
    }
    public async Task RemoveTokenAsync(ApplicationUser user, string loginProvider, string name, CancellationToken cancellationToken = default) =>
        await _context.UserTokens.DeleteOneAsync(x => x.UserId == user.Id && x.LoginProvider == loginProvider && x.Name == name, cancellationToken);
    public async Task<string?> GetTokenAsync(ApplicationUser user, string loginProvider, string name, CancellationToken cancellationToken = default)
    {
        var token = await _context.UserTokens.Find(x => x.UserId == user.Id && x.LoginProvider == loginProvider && x.Name == name).FirstOrDefaultAsync(cancellationToken);
        return token?.Value;
    }

    public Task SetAuthenticatorKeyAsync(ApplicationUser user, string key, CancellationToken cancellationToken = default) =>
        SetTokenAsync(user, "", "AuthenticatorKey", key, cancellationToken);
    public Task<string?> GetAuthenticatorKeyAsync(ApplicationUser user, CancellationToken cancellationToken = default) =>
        GetTokenAsync(user, "", "AuthenticatorKey", cancellationToken);

    public Task ReplaceCodesAsync(ApplicationUser user, IEnumerable<string> recoveryCodes, CancellationToken cancellationToken = default)
    {
        return SetTokenAsync(user, "", "RecoveryCodes", string.Join(';', recoveryCodes), cancellationToken);
    }
    public async Task<bool> RedeemCodeAsync(ApplicationUser user, string code, CancellationToken cancellationToken = default)
    {
        var storedCodes = await GetTokenAsync(user, "", "RecoveryCodes", cancellationToken);
        var codes = storedCodes?.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList() ?? [];
        var removed = codes.Remove(code);
        if (removed)
        {
            await ReplaceCodesAsync(user, codes, cancellationToken);
        }
        return removed;
    }
    public async Task<int> CountCodesAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        var storedCodes = await GetTokenAsync(user, "", "RecoveryCodes", cancellationToken);
        return storedCodes?.Split(';', StringSplitOptions.RemoveEmptyEntries).Length ?? 0;
    }

    public async Task AddOrUpdatePasskeyAsync(ApplicationUser user, UserPasskeyInfo passkey, CancellationToken cancellationToken = default)
    {
        var document = new ApplicationUserPasskey
        {
            UserId = user.Id,
            CredentialId = passkey.CredentialId,
            PublicKey = passkey.PublicKey,
            CreatedAt = passkey.CreatedAt,
            SignCount = passkey.SignCount,
            Transports = passkey.Transports,
            IsUserVerified = passkey.IsUserVerified,
            IsBackupEligible = passkey.IsBackupEligible,
            IsBackedUp = passkey.IsBackedUp,
            AttestationObject = passkey.AttestationObject,
            ClientDataJson = passkey.ClientDataJson,
            Name = passkey.Name
        };
        await _context.UserPasskeys.ReplaceOneAsync(x => x.UserId == user.Id && x.CredentialId == passkey.CredentialId, document, new ReplaceOptions { IsUpsert = true }, cancellationToken);
    }
    public async Task<IList<UserPasskeyInfo>> GetPasskeysAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        var passkeys = await _context.UserPasskeys.Find(x => x.UserId == user.Id).ToListAsync(cancellationToken);
        return passkeys.Select(ToPasskeyInfo).ToList();
    }
    public async Task<ApplicationUser?> FindByPasskeyIdAsync(byte[] credentialId, CancellationToken cancellationToken = default)
    {
        var passkey = await _context.UserPasskeys.Find(x => x.CredentialId == credentialId).FirstOrDefaultAsync(cancellationToken);
        return passkey is null ? null : await FindByIdAsync(passkey.UserId, cancellationToken);
    }
    public async Task<UserPasskeyInfo?> FindPasskeyAsync(ApplicationUser user, byte[] credentialId, CancellationToken cancellationToken = default)
    {
        var passkey = await _context.UserPasskeys.Find(x => x.UserId == user.Id && x.CredentialId == credentialId).FirstOrDefaultAsync(cancellationToken);
        return passkey is null ? null : ToPasskeyInfo(passkey);
    }
    public async Task RemovePasskeyAsync(ApplicationUser user, byte[] credentialId, CancellationToken cancellationToken = default) =>
        await _context.UserPasskeys.DeleteOneAsync(x => x.UserId == user.Id && x.CredentialId == credentialId, cancellationToken);

    public void Dispose()
    {
    }

    private static UserPasskeyInfo ToPasskeyInfo(ApplicationUserPasskey passkey)
    {
        var info = new UserPasskeyInfo(passkey.CredentialId, passkey.PublicKey, passkey.CreatedAt, passkey.SignCount, passkey.Transports, passkey.IsUserVerified, passkey.IsBackupEligible, passkey.IsBackedUp, passkey.AttestationObject, passkey.ClientDataJson)
        {
            Name = passkey.Name
        };
        return info;
    }

}
