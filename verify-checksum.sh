#!/bin/bash

# Script to verify SHA256 checksums for Vulcan Learning Pit packages

set -e

# Colors for output
GREEN='\033[0;32m'
RED='\033[0;31m'
BLUE='\033[0;34m'
NC='\033[0m' # No Color

if [ $# -eq 0 ]; then
    echo -e "${BLUE}Usage: $0 <package-file>${NC}"
    echo ""
    echo "Examples:"
    echo "  $0 VulcanLearningPit-linux-x64.tar.gz"
    echo "  $0 VulcanLearningPit-win-x64.zip"
    exit 1
fi

PACKAGE_FILE=$1
CHECKSUM_FILE="${PACKAGE_FILE}.sha256"

# Check if files exist
if [ ! -f "${PACKAGE_FILE}" ]; then
    echo -e "${RED}Error: Package file '${PACKAGE_FILE}' not found!${NC}"
    exit 1
fi

if [ ! -f "${CHECKSUM_FILE}" ]; then
    echo -e "${RED}Error: Checksum file '${CHECKSUM_FILE}' not found!${NC}"
    exit 1
fi

echo -e "${BLUE}Verifying checksum for ${PACKAGE_FILE}...${NC}"

# Verify the checksum
if sha256sum -c "${CHECKSUM_FILE}" 2>/dev/null; then
    echo -e "${GREEN}✓ Checksum verification PASSED${NC}"
    echo -e "${GREEN}The package is authentic and has not been tampered with.${NC}"
    exit 0
else
    echo -e "${RED}✗ Checksum verification FAILED${NC}"
    echo -e "${RED}WARNING: The package may have been corrupted or tampered with!${NC}"
    echo -e "${RED}Do NOT use this package.${NC}"
    exit 1
fi
