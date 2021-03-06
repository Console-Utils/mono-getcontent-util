# getcontent

## Description

[![CD](https://github.com/emilyseville7cfg/mono-getcontent/actions/workflows/cd.yml/badge.svg)](https://github.com/emilyseville7cfg/mono-getcontent/actions/workflows/cd.yml)

> ⚠️ This project is no longer maintained.

getcontent - program to view text files.

## Options

- `-h`|`--help` - prints help and exits
- `-v`|`--version` - prints version and exits
- `-f`|`--file` - specifies file name to view
- `-n`|`--number` - use line numbering
- `!-n`|`!--number` - don't use line numbering
- `-N`|`--name` - show file names
- `!-N`|`!--name` - don't show file names
- `-F`|`--format` - specify output format (%n - line number, %s - file string)
- `!-F`|`!--format` - use default output format (%s)

> ⚠️ To use %n in `-F`|`--format` you must specify `-n`|`--number` before it.

## Examples

```bat
getcontent --help
```

```bat
getcontent --file test.txt
```

```bat
getcontent --number --file test.txt
```

```bat
getcontent --name --number --file test.txt
```

```bat
getcontent --name --number --file test.txt !--number --file test1.txt
```
