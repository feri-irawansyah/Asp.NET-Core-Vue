#!/usr/bin/env bash
set -e

dotnet tool restore
dotnet tool run dotnet-script .config/scripts/compile.csx
