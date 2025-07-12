using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Functions;

public static class Functions
{
    public static string ToMD5(this string input)
    {
        using var md5 = MD5.Create();
        var inputBytes = Encoding.UTF8.GetBytes(input);
        var hashBytes = md5.ComputeHash(inputBytes);
        var sb = new StringBuilder();
        foreach (var b in hashBytes)
            sb.Append(b.ToString("x2")); // Convert each byte to a two-digit hexadecimal string
        return sb.ToString();
        //using (var md5 = System.Security.Cryptography.MD5.Create())
        //{
        //    var inputBytes = Encoding.UTF8.GetBytes(input);
        //    var hashBytes = md5.ComputeHash(inputBytes);
        //    return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
        //}
    }
}
