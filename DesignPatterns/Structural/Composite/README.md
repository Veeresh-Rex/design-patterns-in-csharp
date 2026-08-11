# Composite Design Pattern

## Intent
Compose objects into tree structures to represent part-whole hierarchies. Composite lets clients treat individual objects and compositions of objects uniformly.

## Implementation Details
- **Component (`IFileSystemItem`)**: Declares interface for objects in composition.
- **Leaf (`FileItem`)**: Represents leaf objects in composition with no children.
- **Composite (`DirectoryItem`)**: Defines behavior for components having children and stores child components.
