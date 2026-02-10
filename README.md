# XorGate

Simple XOR cryptography library for .NET

## Installation

1. Download `XorGate.dll` from [Releases](https://github.com/PikoCRT/XorGate/releases)
2. Add it to your project:

```xml
<ItemGroup>
  <Reference Include="XorGate">
    <HintPath>libs\XorGate.dll</HintPath>
  </Reference>
</ItemGroup>
```

## Usage

```csharp
using XorGate;

var crypto = new XorCrypto("MySecretKey");

// Encrypt
string encrypted = crypto.Process("Hello World!");

// Decrypt
string decrypted = crypto.Process(encrypted);
```

## Warning

XOR encryption is **not cryptographically secure**. Use only for educational purposes or simple obfuscation.

For real security, use AES, RSA, or other proven algorithms.

## Build from source

```bash
git clone https://github.com/PikoCRT/XorGate.git
cd XorGate
dotnet build -c Release
```

## License

MIT
