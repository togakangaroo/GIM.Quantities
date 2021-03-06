require 'rake'
require 'ftools'

PROJECT_NAME = "GIM.Quantities"
TEST_PROJECT_NAME = "#{PROJECT_NAME}.Tests"
DOT_NET_PATH = "#{ENV["SystemRoot"]}\\Microsoft.NET\\Framework\\v3.5\\"
COMPILE_TARGET = 'Release'
CORE_PROJECT_PATH = "app\\#{PROJECT_NAME}\\"
TEST_PROJECT_PATH = "app\\#{TEST_PROJECT_NAME}\\"
OUTPUT_PATH = "build\\"
DONT_OUTPUT = /^(.*\.pdb)|(log4net\.config)$/
TEST_RUNNER = "tools\\test_runners\\nunit-console.exe"

desc 'Default Method'
task :default => [:test_build,:output_core]

def compile(projectFile, compileTarget = COMPILE_TARGET)
	msBuild = "#{DOT_NET_PATH}\msbuild.exe"
	sh "#{msBuild} /p:Configuration=#{compileTarget} #{projectFile} /t:Rebuild"
end

desc 'Clean output directory'
task :clean do
	sh "rmdir /s/q #{OUTPUT_PATH}" if File.directory? OUTPUT_PATH
	sh "mkdir #{OUTPUT_PATH}"
end
task :build_core => :clean do
	compile("#{CORE_PROJECT_PATH}GIM.Quantities.csproj", COMPILE_TARGET)
end

desc 'Output build'
task :output_core => :build_core do
	source_path = "#{CORE_PROJECT_PATH}bin\\#{COMPILE_TARGET}\\"
	ignore = DONT_OUTPUT
	files = Dir.new(source_path).entries.find_all {|s| (s=~/[a-zA-Z]/) and !(s=~ ignore)} #/
	files.each {|f| File.move source_path+f, OUTPUT_PATH }
end

desc 'Run Tests'
task :test_build => :build_core do
  compile("#{TEST_PROJECT_PATH}\\#{TEST_PROJECT_NAME}.csproj", 'Debug') 
  tests = "#{TEST_PROJECT_PATH}\\bin\\Debug\\#{TEST_PROJECT_NAME}.dll"
  sh "#{TEST_RUNNER} #{tests}"
end

desc 'Increase minor version'
task :minor_version do
	path =  "#{CORE_PROJECT_PATH}\\Properties\\AssemblyInfo.cs"
	assembly_info = File.readlines(path)
	out = File.open(path, "w") { |out|
		is_comment = /^\s*\/\//
  	minor_version_pattern = /\d+(?=\.\*)/
		assembly_info.each do |line|
			out.write line and next if !(line =~ /AssemblyVersion/) || line =~ is_comment
			out.write line.gsub(minor_version_pattern) { |version| version.to_i + 1 }
		end
	}
end