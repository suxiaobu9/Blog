# 使用 Ngrok 測試地端網站

- 先去裝好[Ngrok](https://ngrok.com/download)

- 或是利用 `Chocolatey` 裝 https://community.chocolatey.org/packages/ngrok

辦好 Ngrok 的帳號並且[取得 token](https://dashboard.ngrok.com/get-started/your-authtoken)
![token](.\NgrokImg\token.jpg)

驗證 Ngrok 代理
`ngrok authtoken {Your Token}`
![Authtoken](.\NgrokImg\Authtoken.jpg)

免費的 Ngeok 帳號不能代理 https，所以記得把 SSL 關掉
![SSL](.\NgrokImg\SSL.jpg)

地端
![localhost](.\NgrokImg\localhost.jpg)

下代理指令 `ngrok http {port} -host-header="localhost:{port}"`
![Ready](.\NgrokImg\Ready.jpg)

這裡就是代理的網址
![Go](.\NgrokImg\Go.jpg)
![proxyPage](.\NgrokImg\proxyPage.jpg)

呼叫時 Command Line 也會顯示出被 Request 的東西
![Request](.\NgrokImg\Request.jpg)
