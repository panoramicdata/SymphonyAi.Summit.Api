using System.Text.Encodings.Web;

namespace SymphonyAi.Summit.Api.Converters;

internal class CustomQuoteEncoder : JavaScriptEncoder
{
	private readonly JavaScriptEncoder _encoder = Default;

	public override int MaxOutputCharactersPerInputCharacter
		=> _encoder.MaxOutputCharactersPerInputCharacter;

	public override unsafe int FindFirstCharacterToEncode(char* text, int textLength)
		=> _encoder.FindFirstCharacterToEncode(text, textLength);

	public override unsafe bool TryEncodeUnicodeScalar(int unicodeScalar, char* buffer, int bufferLength, out int numberOfCharactersWritten)
	{
		if (unicodeScalar == 34)
		{
			if (bufferLength < 2)
			{
				numberOfCharactersWritten = 0;
				return false;
			}

			buffer[0] = (char)92;
			buffer[1] = (char)34;
			numberOfCharactersWritten = 2;
			return true;
		}

		return _encoder.TryEncodeUnicodeScalar(unicodeScalar, buffer, bufferLength, out numberOfCharactersWritten);
	}

	public override bool WillEncode(int unicodeScalar) =>
		_encoder.WillEncode(unicodeScalar);
}
