# SpeechRecognition

### 機能
MessageRoll を音声入力

### 動作確認環境

- Windows 10 
- Go 1.11
- Google Chrome 70

### 準備

```yaml
# conf/conf.yaml

profile:
  # Google Chromeのパス
  chrome: "C:/Program Files (x86)/Google/Chrome/Application/chrome.exe"

  # MessageRollが監視するwatchファイル
  watchfile: "./watch.txt"
```
```bat 
go build -o SpeechRecognition.exe .\src\
```

### 使い方

```bat
rem SpeechRecognition.exeのカレントディレクトリで実行
SpeechRecognition.exe
```

※実行時は「ファイアーウォールの許可」「ポップアップ・リダイレクトの許可」「マイクの許可」をしてください。
