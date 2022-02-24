<?php

// find all files in /images and remove Trait_ from the filename and rename files to the new name
$files = glob(__DIR__ . '/images/*.png');

// foreach all files
foreach ($files as $file) {
	// get the filename
	$filename = basename($file);
	// remove Trait_ from the filename
	$newFilename = str_replace('Trait_', '', $filename);
	// rename the file
	rename($file, __DIR__ . '/images/' . $newFilename);
}

$data = file_get_contents(__DIR__ . '/list.txt');
$data = explode("\n", $data);

$not_exists = [];

foreach ($data as $line) {
	$line = trim($line);
	if (file_exists(__DIR__ . '/images/' . $line . '.png')) {
		echo $line . '<br>';
	} else {
		$not_exists[] = $line;
	}
}

// write not_exists.txt
file_put_contents(__DIR__ . '/not_exists.txt', implode("\n", $not_exists));
