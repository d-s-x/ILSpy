// #exclude v2 : compilation error
// #ignore v4r o- : not yet implemented

using System;
using System.IO;

public class Async
{
	public async void StreamCopyToWithConfigureAwait(Stream destination, int bufferSize)
	{
		byte[] array = new byte[bufferSize];
		int count;
		while ((count = await destination.ReadAsync(array, 0, array.Length).ConfigureAwait(false)) != 0)
		{
			await destination.WriteAsync(array, 0, count).ConfigureAwait(false);
		}
	}
}
