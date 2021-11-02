---
title: 'Big-Endian vs Little-Endian'
published: 2021-10-30
lead: 'If you've done any significant amount of programming, especially dealing with networking, you probably encountered the term 'Endiannes' and the inevitable follow up 'Big Endian' and 'Little Endian'. Althouth it sounds scary at first, the concept is pretty simple.'
---


# Big Endian vs Little Endian - how computers read data from memory

If you've done any significant amount of programming, especially dealing with networking, you probably encountered the term 'Endiannes' and the inevitable follow up 'Big Endian' and 'Little Endian'. Althouth it sounds scary at first, the concept is pretty simple.

Endiannes basically describes how a computer reads its memory - from left to right or the other way around.

But before we get to that, there are two things we need to get out of the way:
1. What are bits, bytes and words and how they relate to eachother.
2. What does it mean a bit or a byte is the most significant one.

## Bits, bytes and words

When it comes to computers, to them any form of data - be it text, numbers, pictures, music or video -  is eventually a series of 0's and 1's laid out in memory. Those are **bits**.

A **byte** is an arbitrarty number of bits grouped together in a specific order. Most often a byte consists of **eight** bits. Since a bit can only have two possible values (0 and 1) we can say that a byte is a *binary number*. This also means that we can represent a byte in other number systems, for example decimal.

Say we have this series of bits ordered from left to right: `01101001`. Since there are exactly eight of them we know we're dealing with a binary representation of a byte here. If we convert the value to decimal, we get 105. Not a very huge value, is it? As a matter of fact, a typical eight-bit byte can store numbers between 0 and 255. In order to store more information, computers use series of bytes laid out in a specific order in memory.

So just like bits make a byte, a number of bytes form bigger units of data - **words**. A word tells us how many bits can a processor read in one go. You may have heard of 32-bit or 64-bit computer systems - a word is basically that number.

Because a word typically consists of 4 or 8 bytes, it would be cumbersome to use 0's and 1's. Most often we use hexadecimal format when dealing with series of bytes. In our case the byte `01101001` when converted to hex becomes `69`.

## Most and Least Significant Bit and Byte

Let's say we've got this number: `205913`. Which digit, if changed, has the most impact on the value? I think it's obvious for anyone that it's the first digit from the left - 2. If we replace it by any other digit the whole value changes drastically. In contrast, if we change the last digit, the difference in values is very small. We can say that in this case 2 is the most significant digit and 3 is the least.

The same principle applies to bits and bytes. In a byte, the most significant bit is the one that if flipped changes the value the most. Recall from earlier our bits `01101001` when converted to decimal produce the value `105`. If we flip the rightmost bit to 0, the value changes to `104`. If instead we flip the leftmost bit, the value is now `233`.

As you probably know by now, it's the same case for bytes in a word. The number `1264739820` when converted to hexadecimal format is `4b6265ec`. We can split it to four bytes: `4b`, `62`, `65`, `ec`.

Changing the leftmost byte to `9c`:
```
(hex)9c 62 65 ec = (dec)2 623 694 316
```
increases the value by `1358954496`, while changing the rightmost:
```
(hex)4b6265ec = (dec)1 264 739 740
```
increases the value by `80`.

## Endiannes

By now you should have a feeling where this is all going. Endiannes tells us which byte is the most significant one in a series of bytes (it may be a word, but also a stream or array of bytes).

When we say the byte order is **big-endian** we know that the most significant byte is the leftmost one. If you recall our previous example, the number (in hex) `4b6265ec` is written in big-endian because `4b` is the most significant byte.

Bytes ordered in **little-endian**  have the most significant byte at the rightmost position. So again if we want to convert our number `4b6265ec` to little-endian order, we have to 'reverse' it, so it becomes `ec65624b`.


This has implications when exchanging data between systems with incompatible byte ordering schemas. Basically it means data produced by a big-endian system will be read in reverse on a little-endian system if we don't convert it first.

## Should I care?

As long as your code is not crossing machine boundary (meaning it runs on one computer and does not communicate via network) and doesn't read files produced by a different system, you're good. The answer is up to you.
