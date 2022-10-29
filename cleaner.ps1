Get-ChildItem .\ -include bin,obj -Recurse | foreach ($_) { remove-item $_.fullname -Force -Recurse }

$date = Get-Date -Format "dd.MM.yyyy"
$zipName = 'Kuchejda Maciej ' + $date + '.zip'
Compress-Archive -Path * $zipName