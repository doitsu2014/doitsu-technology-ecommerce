# Introduce


## Notes


1. Install diesel_cli on macbook m1

```bash
RUSTFLAGS='-L /opt/homebrew/opt/libpq/lib' cargo install diesel_cli --no-default-features --features postgres
```

Linux

```bash
RUSTFLAGS='-L /home/linuxbrew/.linuxbrew/opt/libpq/lib' cargo install diesel_cli --no-default-features --features postgres
```
