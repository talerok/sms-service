#!/usr/bin/env python3
"""Build and run the SMS Service via docker-compose."""

import subprocess
import sys


def run(cmd: list[str]) -> None:
    print(f">>> {' '.join(cmd)}")
    result = subprocess.run(cmd, cwd=sys.path[0] or ".")
    if result.returncode != 0:
        print(f"Command failed with exit code {result.returncode}")
        sys.exit(result.returncode)


def main() -> None:
    run(["docker", "compose", "build"])
    run(["docker", "compose", "up", "-d"])
    print("\nSMS Service is running at http://localhost:5075")
    print("  POST http://localhost:5075/api/sms/send")
    print("  GET  http://localhost:5075/          (log page)")
    print("\nTo stop: docker compose down")


if __name__ == "__main__":
    main()
