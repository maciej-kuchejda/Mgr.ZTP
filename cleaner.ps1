Get-ChildItem .\ -include bin,obj -Recurse | foreach ($_) { remove-item $_.fullname -Force -Recurse }

$date = Get-Date -Format "MMdd"
$zipName = 'Kuchejda_' + $date + '.zip'
Compress-Archive -Path * $zipName