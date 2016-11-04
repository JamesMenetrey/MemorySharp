# MemorySharp Library Changelog

The log of changes made to MemorySharp Library.

## V1.2 (21 September 2016)

Enhancements:

- Rewrite the read operations for arrays to have much better performance.
- Rewrite the write operations for arrays to have much better performance.
- Heavily improve the performance of write operations when a relative address is provided (the main module of the remote process is now cached).

Bugfixes:

- Properly read strings without a \0 delimiter instead of throwing an ArgumentOutOfRangeException.

## V1.1.1 (05 September 2016)

Bugfixes:

- Threads created using the library are properly returned by the API.

## V1.1 (25 March 2014)

Bugfixes:

- The method `SendInputMouse.ReleaseLeft()`, properly releases the left click of the mouse.

## V1.0 (10 July 2013)

- Initial Release