// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License
// See the LICENSE file in the project root for more information.
// Maintainer: Argo Zhang(argo@live.ca) Website: https://www.blazor.zone

using System.Text;

namespace BootstrapBlazor.Components;

class DefaultTotpService : ITotpService
{
    private static readonly Random _random = new();
    private const string Base32Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";

    public TotpInstanceBase Instance { get; } = new DefaultTotpInstance();

    public string Compute(string secretKey, int period = 30, OtpHashMode mode = OtpHashMode.Sha1, int digits = 6, DateTime? timestamp = null) => "123456";

    public string GenerateOtpUri(OtpOptions? options = null) => "otpauth://totp/BootstrapBlazor?secret=OMM2LVLFX6QJHMYI&issuer=Simulator";

    public string GenerateSecretKey(int length = 20)
    {
        var sb = new StringBuilder(length);
        for (int i = 0; i < length; i++)
        {
            sb.Append(Base32Chars[_random.Next(Base32Chars.Length)]);
        }
        return sb.ToString();
    }

    public int GetRemainingSeconds(DateTime? timestamp = null) => 30;

    public byte[] GetSecretKeyBytes(string input) => [];

    public bool Verify(string code, DateTime? timestamp = null) => false;

    class DefaultTotpInstance : TotpInstanceBase
    {
        public override int GetRemainingSeconds(DateTime? timestamp = null) => 30;

        public override bool Verify(string code, DateTime? timestamp = null) => false;
    }
}
