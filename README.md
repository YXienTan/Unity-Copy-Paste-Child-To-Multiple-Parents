# Unity-Paste-Child-To-Multiple-Parents

**PasteChildToMultipleParents** is a Unity Editor script that allows users to copy one or multiple child objects and paste them under multiple selected parent objects in the hierarchy. This tool enhances productivity when working with complex object hierarchies, especially when you need to manage and organize child objects across several parent objects.

## Features

- Copy one or multiple child objects from the hierarchy.
- Paste the copied child objects to multiple selected parent objects.
- Supports Prefabs: If a copied object is a prefab, the pasted object will be an instance of that prefab.
- Undo support for both copying and pasting actions.
- Automatically clears copied objects when the window is closed.

## How to Use

1. Open Unity and select the objects you want to copy in the Hierarchy.
2. Go to **Tools -> Paste Child To Selected Parents** to open the script window.
3. Click **Copy Child** to copy the selected child object(s).
4. Select one or more parent objects in the Hierarchy.
5. Click **Paste Child** to paste the copied objects under the selected parent objects.

## Installation

1. Download or clone this repository to your local machine.
2. Place the `PasteChildToMultipleParents.cs` file into your Unity project’s `Editor` folder.
3. Open Unity and find the tool under **Tools -> Paste Child To Selected Parents** in the menu bar.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

# Unity-Paste-Child-To-Multiple-Parents (中文)

**PasteChildToMultipleParents** 是一个 Unity 编辑器脚本，允许用户复制一个或多个子对象，并将它们粘贴到层级视图中多个已选中的父对象下。该工具旨在提升在处理复杂对象层级结构时的生产力，特别是在需要管理和组织多个父对象下的子对象时。

## 功能

- 从层级视图中复制一个或多个子对象。
- 将复制的子对象粘贴到多个已选中的父对象下。
- 支持预制件：如果复制的对象是预制件，粘贴出的对象将是该预制件的实例。
- 支持撤销操作，适用于复制和粘贴操作。
- 当窗口关闭时，会自动清空复制的对象。

## 使用方法

1. 打开 Unity 并在层级视图中选择要复制的对象。
2. 前往 **Tools -> Paste Child To Selected Parents** 打开脚本窗口。
3. 点击 **Copy Child** 以复制选中的子对象。
4. 在层级视图中选择一个或多个父对象。
5. 点击 **Paste Child** 以将复制的子对象粘贴到选定的父对象下。

## 安装

1. 下载或克隆此存储库到本地计算机。
2. 将 `PasteChildToMultipleParents.cs` 文件放入 Unity 项目的 `Editor` 文件夹中。
3. 打开 Unity，并在菜单栏中的 **Tools -> Paste Child To Selected Parents** 找到该工具。

## 许可证

此项目基于 MIT 许可证授权 - 有关详细信息，请参阅 [LICENSE](LICENSE) 文件。
