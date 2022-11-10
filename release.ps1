cd ./bin/Release/net7.0/publish/linux

rm ./app.db
rm ./app.db-shm
rm ./app.db-wal

tar -czvf ../box.tar.gz ./*

cd ../../../../../