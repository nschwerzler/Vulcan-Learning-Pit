#!/bin/bash

# Script to build packages and generate SHA256 checksums for Vulcan Learning Pit

set -e

# Colors for output
GREEN='\033[0;32m'
BLUE='\033[0;34m'
NC='\033[0m' # No Color

echo -e "${BLUE}Building Vulcan Learning Pit packages...${NC}"

# Define platforms
platforms=("linux-x64" "win-x64" "osx-x64" "osx-arm64")

# Clean previous builds
rm -rf ./publish
rm -f VulcanLearningPit-*.tar.gz VulcanLearningPit-*.zip
rm -f VulcanLearningPit-*.sha256

# Build for each platform
for platform in "${platforms[@]}"; do
    echo -e "\n${GREEN}Building for ${platform}...${NC}"
    
    dotnet publish src/VulcanLearningPit/VulcanLearningPit.csproj \
        -c Release \
        -r ${platform} \
        --self-contained true \
        -p:PublishSingleFile=true \
        -p:PublishTrimmed=true \
        -o ./publish/${platform}
    
    # Create archives
    cd ./publish/${platform}
    
    if [[ ${platform} == win-* ]]; then
        # Windows: Create zip
        zip -r ../../VulcanLearningPit-${platform}.zip .
        cd ../..
        
        # Generate checksum
        sha256sum VulcanLearningPit-${platform}.zip > VulcanLearningPit-${platform}.zip.sha256
        echo -e "${GREEN}Created VulcanLearningPit-${platform}.zip and checksum${NC}"
        cat VulcanLearningPit-${platform}.zip.sha256
    else
        # Linux/macOS: Create tar.gz
        tar -czf ../../VulcanLearningPit-${platform}.tar.gz .
        cd ../..
        
        # Generate checksum
        sha256sum VulcanLearningPit-${platform}.tar.gz > VulcanLearningPit-${platform}.tar.gz.sha256
        echo -e "${GREEN}Created VulcanLearningPit-${platform}.tar.gz and checksum${NC}"
        cat VulcanLearningPit-${platform}.tar.gz.sha256
    fi
done

echo -e "\n${BLUE}All packages built successfully!${NC}"
echo -e "${BLUE}Package files and their checksums are in the current directory.${NC}"
