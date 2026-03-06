# Todo Dashboard 專案

一個使用 Blazor Server、Tailwind CSS 和 SQLite 建立的現代化待辦事項管理系統。

## 功能特色

- ✅ 完整的 CRUD 操作（新增、讀取、更新、刪除）
- 📊 Dashboard 統計資訊顯示
- 🎨 使用 Tailwind CSS 打造的現代化 UI
- 💾 本地 SQLite 資料庫儲存
- ⚡ Blazor Server 即時互動
- 🏷️ 任務優先級和分類管理
- ✓ 任務完成狀態切換

## 技術堆疊

- **前端框架**: Blazor Server (.NET 10)
- **樣式**: Tailwind CSS v3
- **資料庫**: SQLite
- **ORM**: Entity Framework Core 10

## 開始使用

### 1. 安裝相依套件

```bash
# 還原 .NET 套件
dotnet restore

# 安裝 npm 套件
cd TodoApps
npm install
```

### 2. 編譯 Tailwind CSS

開發時建議使用 watch 模式：

```bash
npm run watch:css
```

或手動建置：

```bash
npm run build:css
```

### 3. 執行應用程式

```bash
dotnet run
```

應用程式將在 `https://localhost:5001` 啟動。

## 專案結構

```
TodoApps/
├── Components/
│   ├── Pages/
│   │   └── Dashboard.razor      # 主要 Dashboard 頁面
│   └── App.razor                 # 應用程式根元件
├── Data/
│   └── TodoDbContext.cs          # Entity Framework DbContext
├── Models/
│   └── TodoItem.cs               # Todo 資料模型
├── Services/
│   └── TodoService.cs            # Todo 業務邏輯服務
├── Styles/
│   └── app.css                   # Tailwind CSS 來源檔
├── wwwroot/
│   └── css/
│       └── app.css               # 編譯後的 CSS
├── Program.cs                    # 應用程式進入點
└── todos.db                      # SQLite 資料庫檔案（執行後自動建立）
```

## 資料庫

專案使用 SQLite 作為本地資料庫，資料庫檔案 `todos.db` 會在首次執行時自動建立在專案根目錄。

### TodoItem 資料表結構

| 欄位 | 類型 | 說明 |
|------|------|------|
| Id | int | 主鍵 |
| Title | string | 任務標題（必填） |
| Description | string | 任務描述 |
| IsCompleted | bool | 完成狀態 |
| CreatedAt | DateTime | 建立時間 |
| CompletedAt | DateTime? | 完成時間 |
| Priority | string | 優先級（Low/Medium/High） |
| Category | string | 分類標籤 |

## 開發說明

### Tailwind CSS 開發流程

1. 修改 `.razor` 檔案中的 Tailwind class
2. 確保 `npm run watch:css` 正在執行
3. CSS 會自動重新編譯
4. 重新整理瀏覽器查看變更

### 建置流程

專案已設定在 `dotnet build` 時自動執行 `npm run build:css`，確保 CSS 始終是最新的。

## 授權

MIT License
