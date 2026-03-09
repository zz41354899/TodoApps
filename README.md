# 📋 Notion 風格 TodoList

一個功能豐富、設計精美的待辦事項管理系統，採用 Notion 風格的簡潔介面設計，使用 Blazor Server、Bootstrap 和 SQLite 建立。

![Blazor](https://img.shields.io/badge/Blazor-512BD4?style=for-the-badge&logo=blazor&logoColor=white)
![.NET](https://img.shields.io/badge/.NET_10-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-07405E?style=for-the-badge&logo=sqlite&logoColor=white)

## ✨ 功能特色

### 🎯 核心功能
- ✅ **完整 CRUD 操作** - 新增、編輯、刪除、完成任務
- � **即時搜尋** - 快速搜尋任務標題和描述
- 🎨 **32 個可選 Icon** - 為每個任務選擇專屬圖示
- ⭐ **星號標記** - 標記重要任務
- 📅 **截止日期** - 設定任務期限，自動提示逾期
- �️ **標籤系統** - 使用多個標籤分類任務
- 🔄 **重複任務** - 支援每日、每週、每月重複

### � 進階功能
- **智能篩選**
  - 全部任務
  - 進行中任務
  - 已完成任務
  - 已加星號任務
  - 已逾期任務

- **多種排序**
  - 建立時間
  - 截止日期
  - 優先級
  - 標題（字母順序）

- **批次操作**
  - 批次選擇任務
  - 批次標記完成
  - 批次刪除
  - 全選功能

### 📈 任務管理
- 🎯 **優先級** - 高/中/低三個等級
- 📂 **分類** - 自訂分類標籤
- ⏱️ **預估時間** - 記錄預估完成時間
- ✓ **子任務進度** - 追蹤子任務完成情況（例如：3/5）
- 📝 **備註** - 額外的詳細說明

### 🎨 設計特色
- **Notion 風格介面** - 簡潔、優雅的白色設計
- **響應式 Hover** - 滑鼠懸停顯示操作按鈕
- **視覺提示** - 逾期任務紅色邊框警示
- **彩色標籤** - 藍色標籤、紅色逾期提示
- **進度追蹤** - 子任務完成度一目了然

## 🛠️ 技術堆疊

| 技術 | 版本 | 用途 |
|------|------|------|
| **Blazor Server** | .NET 10 | 前端框架 |
| **Bootstrap** | 5.3 | UI 樣式框架 |
| **SQLite** | - | 本地資料庫 |
| **Entity Framework Core** | 10 | ORM |

## 🚀 快速開始

### 前置需求
- [.NET 10 SDK](https://dotnet.microsoft.com/download)

### 安裝步驟

1. **Clone 專案**
```bash
git clone https://github.com/你的帳號/TodoApps.git
cd TodoApps
```

2. **還原 .NET 套件**
```bash
dotnet restore
```

3. **執行應用程式**
```bash
cd TodoApps
dotnet run
```

4. **開啟瀏覽器**
```
http://localhost:5298
```

> 💡 **注意**：本專案使用 Bootstrap CDN，無需額外安裝 npm 套件或編譯 CSS。

## 📁 專案結構

```
TodoApps/
├── Components/
│   ├── Layout/
│   │   ├── MainLayout.razor      # 主要佈局
│   │   └── Sidebar.razor         # 側邊欄導航
│   ├── Pages/
│   │   └── Dashboard.razor       # 主要 Dashboard 頁面
│   ├── Shared/
│   │   ├── TodoFilters.razor     # 篩選和排序元件
│   │   ├── TodoListItem.razor    # 任務項目元件
│   │   ├── TodoModal.razor       # 新增/編輯 Modal
│   │   └── IconPicker.razor      # 圖示選擇器
│   └── App.razor                 # 應用程式根元件
├── Data/
│   └── TodoDbContext.cs          # Entity Framework DbContext
├── Models/
│   └── TodoItem.cs               # Todo 資料模型
├── Services/
│   └── TodoService.cs            # Todo 業務邏輯服務
├── wwwroot/
│   └── app.css                   # 自訂 CSS 樣式
├── Program.cs                    # 應用程式進入點
└── todos.db                      # SQLite 資料庫（自動建立）
```

## 💾 資料庫結構

### TodoItem 資料表

| 欄位 | 類型 | 說明 |
|------|------|------|
| **Id** | int | 主鍵（自動遞增） |
| **Title** | string(200) | 任務標題（必填） |
| **Description** | string(1000) | 任務描述 |
| **Icon** | string(10) | 任務圖示 Emoji |
| **IsCompleted** | bool | 完成狀態 |
| **IsStarred** | bool | 星號標記 |
| **Priority** | string(20) | 優先級（Low/Medium/High） |
| **Category** | string(50) | 分類標籤 |
| **Tags** | string(500) | 標籤（逗號分隔） |
| **DueDate** | DateTime? | 截止日期 |
| **CreatedAt** | DateTime | 建立時間 |
| **CompletedAt** | DateTime? | 完成時間 |
| **RecurringType** | string(20) | 重複類型（Daily/Weekly/Monthly） |
| **RecurringInterval** | int? | 重複間隔 |
| **SubTasksTotal** | int | 子任務總數 |
| **SubTasksCompleted** | int | 已完成子任務數 |
| **EstimatedMinutes** | int | 預估完成時間（分鐘） |
| **AssignedTo** | string(100) | 指派對象 |
| **Notes** | string(2000) | 備註 |

## 🎯 使用範例

### 建立緊急任務
```
標題：完成專案報告
Icon：📊
優先級：高
截止日期：明天
標籤：緊急, 專案A
預估時間：120 分鐘
加星號：⭐
```

### 設定重複任務
```
標題：每日站立會議
Icon：💻
重複：每日
預估時間：15 分鐘
```

### 追蹤子任務
```
標題：網站開發
子任務：3/10（已完成 3 個，共 10 個）
```

## 🔧 開發指南

### 樣式開發

本專案使用 **Bootstrap 5.3** 作為 UI 框架：

- **Bootstrap CDN**：透過 CDN 引入，無需本地安裝
- **自訂樣式**：可在 `wwwroot/app.css` 中新增自訂 CSS
- **即時預覽**：修改 `.razor` 檔案後，重新整理瀏覽器即可看到變更

### Bootstrap 類別使用範例
```html
<!-- Flexbox 佈局 -->
<div class="d-flex align-items-center gap-2">
  
<!-- 按鈕樣式 -->
<button class="btn btn-primary btn-sm">按鈕</button>

<!-- 表單控制項 -->
<input type="text" class="form-control form-control-sm">
```

### 資料庫管理

**重置資料庫**（清空所有資料）
```bash
# 刪除資料庫檔案
Remove-Item TodoApps/todos.db*

# 重新執行應用程式，資料庫會自動重建
dotnet run
```

## 📸 功能截圖

### 主要介面
- 簡潔的 Notion 風格設計
- 搜尋和篩選功能
- 任務列表顯示

### 新增/編輯任務
- Icon 選擇器
- 完整的任務屬性設定
- 星號標記

### 批次操作
- 多選任務
- 批次完成/刪除

## 🤝 貢獻

歡迎提交 Issue 和 Pull Request！

## 📄 授權

MIT License

## 👨‍💻 作者

建立於 2026 年

---

⭐ 如果這個專案對你有幫助，請給個星星！
