function [terrain_positions_XY] = terrain_object_position_generator(x_length,y_length,x_center,y_center,num_objects,min_distance)
%TERRAIN_OBJECT_POSITION_GENERATOR Creates the XY position of a given set
%of objects (num_objects) within certain space constraints (x_variation,y_variation)
%center objects based on their panel center (x_center,y_center)

terrain_positions_XY = zeros(num_objects,2);

ax = x_length/-2;
bx = x_length/2;

ay = y_length/-2;
by = y_length/2;

count = 1;

while count <= num_objects

    if count == 1
        
        rx = ax + (bx-ax).*rand(1,1); % formula snagged from: https://www.mathworks.com/help/matlab/ref/rand.html
        ry = ay + (by-ay).*rand(1,1);
        
        terrain_positions_XY(count,:) = [rx,ry];

        count = count + 1;

    elseif count > 1
       
        rx = ax + (bx-ax).*rand(1,1);
        ry = ay + (by-ay).*rand(1,1);

        dist_from_others = zeros(count-1,1);

        for p = 1:count-1

            dist_from_others(p) = pdist([terrain_positions_XY(p,1),terrain_positions_XY(p,2);rx,ry],'euclidean');

        end

        if sum(dist_from_others > min_distance) == length(dist_from_others)

           terrain_positions_XY(count,:) = [rx,ry];

           count = count + 1;

        end

    end

end

terrain_positions_XY = terrain_positions_XY + [x_center,y_center];

end

