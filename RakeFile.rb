require 'rake'
require 'ftools'

PROJECT_NAME = "GIM.Quantities"
TEST_PROJECT_NAME = "#{PROJECT_NAME}.Tests"
DOT_NET_PATH = "#{ENV["SystemRoot"]}\\Microsoft.NET\\Framework\\v3.5\\"
COMPILE_TARGET = 'Release'
CORE_PROJECT_PATH = "app\\#{PROJECT_NAME}\\"
TEST_PROJECT_PATH = "app\\#{TEST_PROJECT_NAME}\\"
OUTPUT_PATH = "bin\\"
DONT_OUTPUT = /^(.*\.pdb)|(log4net\.config)$/
TEST_RUNNER = "tools\\test_runners\\nunit-console.exe"

desc 'Default Method'
task :default => [:test_build,:output_core]

def compile(projectFile, compileTarget = COMPILE_TARGET)
	msBuild = "#{DOT_NET_PATH}\msbuild.exe"
	sh "#{msBuild} /p:Configuration=Release #{projectFile} /t:Rebuild"
end

desc 'Clean output directory'
task :clean do
	sh "rmdir /s/q #{OUTPUT_PATH}" if File.directory? OUTPUT_PATH
	sh "mkdir #{OUTPUT_PATH}"
end
task :build_core => :clean do
	compile("#{CORE_PROJECT_PATH}GIM.Quantities.csproj", COMPILE_TARGET)
end
task :output_core => :build_core do
	source_path = "#{CORE_PROJECT_PATH}bin\\#{COMPILE_TARGET}\\"
	ignore = DONT_OUTPUT
	files = Dir.new(source_path).entries.find_all {|s| (s=~/[a-zA-Z]/) and !(s=~ ignore)} #/
	files.each {|f| File.move source_path+f, OUTPUT_PATH }
end
task :test_build => :build_core do
  compile("#{TEST_PROJECT_PATH}\\#{TEST_PROJECT_NAME}.csproj", 'Debug') 
  tests = "#{TEST_PROJECT_PATH}\\bin\\Debug\\#{TEST_PROJECT_NAME}.dll"
  sh "#{TEST_RUNNER} #{tests}"
end